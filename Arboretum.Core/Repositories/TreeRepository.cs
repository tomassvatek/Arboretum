using Arboretum.Core.Models.Entities;
using Arboretum.Core.Modules.Locations;
using Arboretum.Core.WebServices;
using Arboretum.Core.WebServices.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arboretum.Core.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly HttpClient _httpClient;

        public TreeRepository( IDataProvider provider )
        {
            _httpClient = new HttpClient( provider );
        }


        public async Task<IEnumerable<Tree>> GetTrees( IMapViewport viewport )
        {
            var trees = await _httpClient.ReadManyAsync( $"?lat_min={viewport.SouthWest.Latitude}&lat_max={viewport.NorthEast.Latitude}&lon_min={viewport.SouthWest.Longitude}&lon_max={viewport.NorthEast.Longitude}" );
            //var db = trees.Where( t => (t.LatLng.Latitude > viewport.SouthWest.Latitude && t.LatLng.Latitude < viewport.NorthEast.Latitude) && (t.LatLng.Longitude > viewport.SouthWest.Longitude && t.LatLng.Longitude < viewport.NorthEast.Longitude) );
            return trees;
        }

        public Tree GetTrees( QuizOption option, IMapViewport viewport )
        {
            throw new NotImplementedException( );
        }

        public Tree GetTreeById( int id )
        {
            return new Tree( ) { SpeciesCommonName = "Lípa" };
            //throw new NotImplementedException();
        }
    }
}
