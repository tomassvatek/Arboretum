﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Common.Enums;
using Arboretum.WebService.HttpClient;
using Arboretum.WebService.Providers;
using Arboretum.WebService.Providers.Interfaces;
using Arboretum.WebService.Providers.SPK;

namespace Arboretum.WebService
{
    public class RestRepository : IRestRepository
    {
        private readonly IHttpClient _httpClient;
        private readonly List<ITreeDataProvider> _treeProviders = new List<ITreeDataProvider>();

        public RestRepository(IHttpClient httpClient)
        {
            _httpClient = httpClient;
            RegisterProviders();
        }

        /// <summary>
        /// Gets the trees asynchronous.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        public async Task<IList<ITree>> GetTreesAsync(IRegion region)
        {
            var trees = new List<ITree>();

            foreach (var treeProvider in _treeProviders)
            {
                var providerTrees = await treeProvider.GetTreesAsync(region);
                if (providerTrees != null)
                {
                    trees.AddRange(providerTrees);
                    providerTrees.Clear();
                }
            }
            return trees;
        }

        /// <summary>
        /// Gets the tree by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Provider with id={id}</exception>
        public async Task<ITree> GetTreeByIdAsync(int id, ProviderName providerName)
        {
            var provider = GetProviderByName(providerName);
            if (provider == null)
            {
                throw new ArgumentException($"Provider with id={id} does not exist.");
            }

            var tree = await provider.GetTreeByIdAsync(id);
            return tree;
        }


        /// <summary>
        /// Gets the name of the provider by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private ITreeDataProvider GetProviderByName(ProviderName name)
        {
            return _treeProviders.FirstOrDefault(p => p.Name == name);
        }

        /// <summary>
        /// Registers the providers.
        /// </summary>
        private void RegisterProviders()
        {
            _treeProviders.Add(new SPK(_httpClient));
        }
    }
}