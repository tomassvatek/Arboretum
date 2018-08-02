using System;
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
        public Tree GetTreeById( int id )
        {
            return _unitOfWork.Trees.Get( id );
        }

        public IEnumerable<Tree> GetTrees( IMapViewport mapViewport )
        {
            var trees = _unitOfWork.Trees.GetAll();

            if ( trees != null )
            {
                return null;
            }

            // load tree from SPK

            // get tree in viewport
            foreach ( var tree in trees )
            {
            }

            return trees;
        }

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
            List<Tree> trees = new List<Tree>(treesViewport);

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
    }
}
