using System;
using System.Collections.Generic;
using System.Linq;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Persistence;

namespace Arboretum.Infrastructure.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        protected readonly ArboretumDbContext DbContext;

        public TreeRepository( ArboretumDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public IList<Tree> GetTrees( IRegion region )
        {
            var query = DbContext.Trees
                .Where(t => (t.Latitude > region.LatitudeMin && region.LatitudeMax > t.Latitude) &&
                            (region.LongitudeMin < t.Longitude && region.LongitudeMax > t.Longitude));

            var domainTrees = MapDbTreeToDomain(query).ToList();
            return domainTrees;
        }

        public IList<Dendrology> GetDendrologies( )
        {
            var query = DbContext.Dendrologies;
            var domainDendrologies = MapDbDendrologiesToDomain(query).ToList();
            return domainDendrologies;
        }

        public Dendrology GetDendrologyById( int id )
        {
            var domainDendrologies = GetDendrologies().FirstOrDefault(d => d.Id == id);
            return domainDendrologies;
        }

        public Tree GetTreeById( int id )
        {
            var query = DbContext.Trees.Where(t => t.Id == id);
            var domainTree = MapDbTreeToDomain(query).FirstOrDefault();
            return domainTree;
        }

        public IList<Tree> GetTrees( IRegion region, double latitude, double longitude, int count )
        {
            throw new System.NotImplementedException( );
        }


        public Tree CreateTree( Tree tree )
        {
            throw new System.NotImplementedException( );
        }

        public void DeleteTree( int id )
        {
            throw new System.NotImplementedException( );
        }

        public void UpdateTree( int id, Tree tree )
        {
            throw new System.NotImplementedException( );
        }

        private IQueryable<Tree> MapDbTreeToDomain( IQueryable<Persistence.Entities.Tree> query )
        {
            return query.Select( t => new Tree
            {
                Id = t.Id,
                Age = t.Age,
                CrownSize = t.CrownSize,
                Height = t.Height,
                TrunkSize = t.TrunkSize,
                Note = t.Note,
                IsEditable = true,
                Location = new Location
                {
                    Latitude = t.Latitude,
                    Longitude = t.Longitude
                },
                Dendrology = new Dendrology
                {
                    Id = t.Dendrology.Id,
                    CommonName = t.Dendrology.CommonName,
                    ScientificName = t.Dendrology.ScientificName,
                    About = t.Dendrology.About
                }
            } );
        }

        private IQueryable<Dendrology> MapDbDendrologiesToDomain( IQueryable<Persistence.Entities.Dendrology> query )
        {
            return query.Select( d => new Dendrology
            {
                Id = d.Id,
                CommonName = d.CommonName,
                ScientificName = d.ScientificName,
                About = d.About
            } );
        }
    }
}