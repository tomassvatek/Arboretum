using System.Collections.Generic;
using Arboretum.Core.Extensions;
using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using Arboretum.Core.Repositories;
using Arboretum.Core.WebServices;

namespace Arboretum.Core.Services
{
    public class TreeService : ITreeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestService _restService;

        public TreeService( )
        {
            _unitOfWork = new UnitOfWork( new ArboretumContext( ) );
            _restService = new RestService( );
        }

        /// <summary>
        /// Gets the tree by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Tree GetTree( int id )
        {
            return _unitOfWork.Trees.Get( id );
        }

        /// <summary>
        /// Gets the trees.
        /// </summary>
        /// <param name="mapViewport">The map viewport.</param>
        /// <returns></returns>
        public IEnumerable<Tree> GetTrees( IMapViewport mapViewport )
        {
            var trees = new List<Tree>( );
            var db = _unitOfWork.Trees.GetAll( );

            if ( db != null )
            {
                foreach ( var item in db )
                {
                    if ( mapViewport.Include( item ) )
                    {
                        item.Dendrology = GetDendrology( item.DendrologyId );
                        trees.Add( item );
                    }
                }
            }

            // load tree from SPK

            return trees;
        }

        /// <summary>
        /// Gets the trees.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tree> GetTrees( )
        {
            var trees = _unitOfWork.Trees.GetAll();

            if ( trees == null )
            {
                return null;
            }

            return trees;
        }


        /// <summary>
        /// Gets the trees.
        /// </summary>
        /// <param name="viewport">The viewport.</param>
        /// <param name="currentLocation">The current location.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public Tree GetTrees( IMapViewport viewport, LatLng currentLocation, int count = 5 )
        {
            var treesViewport = GetTrees(viewport);
            var trees = new List<Tree>(treesViewport);

            if ( trees != null )
            {
                int length = trees.Count;
                GeolocationResult[] geolocationResult = new GeolocationResult[length];

                for ( int i = 0; i < trees.Count; i++ )
                {
                    geolocationResult[i].Geolocation = trees[i];
                    geolocationResult[i].Distance = trees[i].CalculateGeolocationDistance( currentLocation );
                }
            }

            return null;
        }

        private Dendrology GetDendrology( int id )
        {
            return _unitOfWork.Dendrologies.Get( id );
        }
    }
}
