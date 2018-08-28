using Arboretum.Core.Enums;
using Arboretum.Core.Extensions;
using Arboretum.Core.Helpers;
using Arboretum.Core.Helpers.DataProviders;
using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
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
