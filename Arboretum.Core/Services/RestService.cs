using Arboretum.Core.Entities;
using Arboretum.Core.Helpers.DataProviders;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arboretum.Core.Services
{
    public class RestService
    {
        /// <summary>
        /// Reads the many asynchronous. 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tree>> ReadManyAsync( IMapViewport viewport )
        {
            var providers = RestDataProviderHandler.GetProviders( );
            if ( providers == null )
            {
                return null;
            }

            var trees = new List<Tree>();

            foreach ( var provider in providers )
            {
                var data = await provider.FetchDataAsync( viewport );
                trees.AddRange( data );
            }

            return trees;
        }
    }
}
