using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Common.Enums;
using Arboretum.Common.Geolocation;
using Arboretum.Common.ServiceResults;

namespace Arboretum.AppCore.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IRestRepository _restRepository;

        public TreeService(ITreeRepository treeRepository, IRestRepository restRepository)
        {
            _treeRepository = treeRepository;
            _restRepository = restRepository;
        }

        public async Task<ServiceResult<IList<ITree>>> GetTreesAsync(IRegion region)
        {
            var result = new ServiceResult<IList<ITree>>();
            try
            {
                var trees = new List<ITree>();

                var repositoryResult = _treeRepository.GetTrees(region);
                if (repositoryResult != null)
                {
                    trees.AddRange(repositoryResult);
                }

                var restResult = await _restRepository.GetTreesAsync(region);
                if (restResult != null)
                {
                    trees.AddRange(restResult);
                }

                result.Data = trees;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        public async Task<ServiceResult<IList<ITree>>> GetClosestTreesAsync(IRegion region, double latitude, double longitude, int? count = null)
        {
            var result = new ServiceResult<IList<ITree>>();
            try
            {
                var treesServiceResult = await GetTreesAsync(region);

                var geolocationDistanceTable = new GeolocationDistanceTable<ITree>();
                var geolocationResults = geolocationDistanceTable.Calculate(treesServiceResult.Data, latitude, longitude);
                var closestTrees = MapGeolocationResultsToDomainTrees(geolocationResults);

                result.Data = count == null ? closestTrees.ToList() : closestTrees.Take(count.Value).ToList();
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }


        public async Task<ServiceResult<ITree>> GetClosestTree(IRegion region, double latitude, double longitude, string commonName)
        {
            var result = new ServiceResult<ITree>();

            var closestTreesResult = await GetClosestTreesAsync(region, latitude, longitude);
            if (closestTreesResult.HasViolations)
            {
                result.AddViolation("There are no trees in your area.");
                return result;
            }

            var closestTrees = closestTreesResult.Data;
            var closestTree = closestTrees.FirstOrDefault(tree => tree.Dendrology.CommonName == commonName);
            if (closestTree == null)
            {
                result.AddViolation($"There is no {commonName} in your area.");
                return result;
            }

            result.Data = closestTree;
            return result;
        }


        public async Task<ServiceResult<ITree>> GetTreeById(int id, ProviderName providerName)
        {
            if (providerName == ProviderName.ArboretumDb)
            {
                var repositoryResult = GetTreeByIdFromDb(id);
                return repositoryResult;
            }

            var restResult = await GetTreeByIdFromRest(id, providerName);
            return restResult;
        }

        public ServiceResult<ITree> CreateTree(Tree tree)
        {
            var result = new ServiceResult<ITree>();

            try
            {
                var createdTree = _treeRepository.CreateTree(tree);
                result.Data = createdTree;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        //TODO: Upravit logiku, která se řídí podle providera
        public ServiceResult UpdateTree(int id, Tree tree)
        {
            var result = new ServiceResult();

            if (tree.IsEditable)
            {
                result.AddViolation($"Tree with id={id} is not editable.");
                return result;
            }

            try
            {
                _treeRepository.UpdateTree(id, tree);
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        private ServiceResult<ITree> GetTreeByIdFromDb(int id)
        {
            var result = new ServiceResult<ITree>();

            try
            {
                var tree = _treeRepository.GetTreeById(id);
                if (tree == null)
                {
                    result.AddViolation("Tree does not exits");
                    return result;
                }

                result.Data = tree;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }

        private async Task<ServiceResult<ITree>> GetTreeByIdFromRest(int id, ProviderName providerName)
        {
            var result = new ServiceResult<ITree>();

            try
            {
                var tree = await _restRepository.GetTreeByIdAsync(id, providerName);
                if (tree == null)
                {
                    result.AddViolation("Tree does not exits");
                    return result;
                }

                result.Data = tree;
                return result;
            }
            catch (Exception exception)
            {
                result.AddViolation(exception);
                return result;
            }
        }


        private IList<ITree> MapGeolocationResultsToDomainTrees(IList<GeolocationResult> geolocationResults)
        {
            var domainTrees = new List<ITree>();

            foreach (var result in geolocationResults)
            {
                if (!isDuplicateSpecies(domainTrees, (ITree)result.Geolocation))
                {
                    domainTrees.Add((ITree)result.Geolocation);
                }
            }

            return domainTrees;
        }

        private bool isDuplicateSpecies(IList<ITree> trees, ITree tree)
        {
            return trees.Any(t => t.Dendrology.CommonName == tree.Dendrology.CommonName);
        }
    }
}
