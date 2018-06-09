﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.Core.Models.Entities;
using Arboretum.Core.Models.Locations;
using Arboretum.Core.WebServices;
using Arboretum.Core.WebServices.Providers;

namespace Arboretum.Core.Repositories
{
    public class TreeRepository : ITreeRepository
    {
        private readonly HttpClient _httpClient;

        public TreeRepository( IDataProvider provider )
        {
            _httpClient = new HttpClient( provider );
        }

        public Tree GetTreeById( int id )
        {
            throw new NotImplementedException( );
        }

        public async Task<IEnumerable<Tree>> GetTrees( IMapViewport viewport )
        {
            var trees = await _httpClient.ReadManyAsync( $"?lat_min={viewport.SouthWest.Latitude}&lat_max={viewport.NorthEast.Latitude}&lon_min={viewport.SouthWest.Longitude}&lon_max={viewport.NorthEast.Longitude}" );
            //var db = trees.Where( t => (t.LatLng.Latitude > viewport.SouthWest.Latitude && t.LatLng.Latitude < viewport.NorthEast.Latitude) && (t.LatLng.Longitude > viewport.SouthWest.Longitude && t.LatLng.Longitude < viewport.NorthEast.Longitude) );
            return trees;
        }
    }
}
