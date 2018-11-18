using System;
using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Common.Enums;
using Arboretum.Persistence;

namespace Arboretum.Infrastructure.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        protected readonly ArboretumDbContext DbContext;

        public TreeRepository(ArboretumDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IList<ITree> GetTrees(IRegion region)
        {
            var query = DbContext.Trees
                .Where(t => (t.Latitude > region.LatitudeMin && region.LatitudeMax > t.Latitude) &&
                            (region.LongitudeMin < t.Longitude && region.LongitudeMax > t.Longitude));

            var domainTrees = MapDbTreeToDomain(query).ToList();

            return domainTrees;
        }

        public ITree GetTreeById(int id)
        {
            var query = DbContext.Trees.Where(t => t.Id == id);
            var domainTree = MapDbTreeToDomain(query).FirstOrDefault();

            return domainTree;
        }

        //public IList<Tree> GetClosestTrees(IRegion region,  double latitude, double longitude, int count)
        //{
        //    if (count <= 0)
        //    {
        //        throw new ArgumentException("Count must be bigger than 0.");
        //    }

        //    var trees = GetTrees(region);
        //    var sortedTrees = SortTreesByDistance(trees, latitude, longitude).Take(count).ToList();

        //    return sortedTrees;
        //}


        public ITree CreateTree(Tree tree)
        {
            if (tree == null)
            {
                throw new ArgumentException("Tree cannot be null.");
            }

            var dendrologyId = DbContext.Dendrologies.Where(d => d.Id == tree.Dendrology.Id)
                .Select(d => d.Id)
                .FirstOrDefault();

            if (dendrologyId == default(int))
            {
                throw new ArgumentException($"Dendrology with id={tree.Dendrology.Id} does not exits.");
            }

            DbContext.Trees.Add(new Persistence.Entities.Tree
            {
                Age = tree.Age,
                Height = tree.Height,
                CrownSize = tree.CrownSize,
                Latitude = tree.Latitude,
                Longitude = tree.Longitude,
                Note = tree.Note,
                DendrologyId = dendrologyId
            });

            DbContext.SaveChanges();

            return tree;
        }

        public void UpdateTree(int id, Tree tree)
        {
            if (tree == null)
            {
                throw new ArgumentException("Tree cannot be null.");
            }

            var treeToUpdate = DbContext.Trees.FirstOrDefault(t => t.Id == id);
            if (treeToUpdate == null)
            {
                throw new ArgumentException($"Tree with id={id} does not exits.");
            }

            treeToUpdate.CrownSize = tree.CrownSize;
            treeToUpdate.TrunkSize = tree.TrunkSize;
            treeToUpdate.Height = tree.Height;
            treeToUpdate.Note = tree.Note;

            DbContext.Trees.Update(treeToUpdate);
            DbContext.SaveChanges();
        }

        private IQueryable<ITree> MapDbTreeToDomain(IQueryable<Persistence.Entities.Tree> query)
        {
            return query.Select(t => new Tree
            {
                Id = t.Id,
                Age = t.Age,
                CrownSize = t.CrownSize,
                Height = t.Height,
                TrunkSize = t.TrunkSize,
                Note = t.Note,
                Latitude = t.Latitude,
                Longitude = t.Longitude,
                IsEditable = true,
                ProviderName = ProviderName.ArboretumDb,
                Dendrology = new Dendrology
                {
                    Id = t.Dendrology.Id,
                    CommonName = t.Dendrology.CommonName,
                    ScientificName = t.Dendrology.ScientificName,
                    About = t.Dendrology.About
                }
            });
        }

        //private List<Tree> SortTreesByDistance(IList<Tree> trees, double latitude, double longitude)
        //{
        //    var dataTable = new GeolocationDataTable();
        //    var closestTrees = new List<Tree>();

        //    foreach (var tree in trees)
        //    {
        //        var distance = _distanceCalculator.CalculateDistance(new Location(latitude, longitude), new Location(tree.Latitude, tree.Longitude));
        //        dataTable.GeolocationResults.Add(new GeolocationResult(tree, distance));
        //    }

        //    dataTable.GeolocationResults.Sort();

        //    foreach (var item in dataTable.GeolocationResults)
        //    {
        //        closestTrees.Add((Tree)item.Geolocation);
        //    }

        //    return closestTrees;
        //}
    }
}