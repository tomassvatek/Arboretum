using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.WebService.HttpClient;
using Arboretum.WebService.Providers.Interfaces;
using Arboretum.WebService.Providers.SPK;

namespace Arboretum.WebService
{
    public class RestRepository : IRestRepository
    {
        private readonly List<ITreeDataProvider> _treeProviders;
        private readonly IHttpClient _httpClient;

        public RestRepository( IHttpClient httpClient )
        {
            _httpClient = httpClient;
            _treeProviders = new List<ITreeDataProvider>( );
            RegisterProviders( );
        }

        public async Task<IList<Tree>> GetTreesAsync( IRegion region )
        {
            var trees = new List<Tree>();

            foreach ( var treeProvider in _treeProviders )
            {
                trees.AddRange( await treeProvider.GetTreesAsync( region ) );
            }

            return trees;
        }

        private void RegisterProviders( )
        {
            _treeProviders.Add( new SPK( _httpClient ) );
        }
    }
}