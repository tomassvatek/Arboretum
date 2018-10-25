using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Repositories;
using Arboretum.WebService.Interfaces;
using Arboretum.WebService.Providers.SPK;

namespace Arboretum.WebService
{
    public class RestRepository : IRestRepository
    {
        private List<ITreeProvider> _treeProviders = new List<ITreeProvider>();

        public RestRepository( )
        {
            RegisterProviders( );
        }

        public IList<Tree> GetTrees( IMapViewport mapViewport )
        {
            var trees = new List<Tree>();
            trees.Clear( );

            foreach ( var treeProvider in _treeProviders )
            {
                trees = treeProvider.GetTrees( mapViewport );
            }

            return trees;
        }

        private void RegisterProviders( )
        {
            _treeProviders.Add( new SPK( ) );
        }
    }
}