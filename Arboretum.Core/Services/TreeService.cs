using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.Core.Entities;
using Arboretum.Core.Extensions;
using Arboretum.Core.Helpers.Locations;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models;
using Arboretum.Core.Repositories;
using Arboretum.Core.Repositories.Intefaces;
using Arboretum.Core.Services.Interfaces;

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


        public async Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport viewport )
        {
            var trees = new List<Tree>( );
            var db = _unitOfWork.Trees.GetAll( );

            if ( db != null )
            {
                foreach ( var item in db )
                {
                    if ( viewport.Include( item ) )
                    {
                        item.Dendrology = GetDendrology( item.DendrologyId );
                        trees.Add( item );
                    }
                }
            }

            var rest = await _restService.ReadManyAsync( viewport );
            if ( rest != null )
            {
                foreach ( var item in rest )
                {
                    trees.Add( item );
                }
            }

            return trees;
        }


        public async Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport viewport, LatLng currentLocation, int count = 5 )
        {
            var treesViewport = await GetTreesAsync( viewport );
            var trees = new List<Tree>( treesViewport );

            if ( trees != null )
            {
                int length = trees.Count;
                GeolocationDataTable dataTable = new GeolocationDataTable( );

                foreach ( var tree in trees )
                {
                    dataTable.Items.Add( new GeolocationResult( )
                    {
                        Geolocation = tree,
                        Distance = tree.CalculateGeolocationDistance( currentLocation )
                    } );
                }

                dataTable.Items.Sort( );
                trees.Clear( );

                foreach ( var item in dataTable.Items )
                {
                    trees.Add( (Tree)item.Geolocation );
                }
            }

            return trees.Take( count );
        }

        public Tree GetTree( int id )
        {
            return _unitOfWork.Trees.Get( id );
        }

        public Dendrology GetDendrology( int id )
        {
            return _unitOfWork.Dendrologies.Get( id );
        }

        public bool Create( Tree tree )
        {
            try
            {
                _unitOfWork.Trees.Add( tree );
                _unitOfWork.SaveChanges( );
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public bool Edit( int id, Tree tree )
        {
            throw new System.NotImplementedException( );
        }
    }
}
