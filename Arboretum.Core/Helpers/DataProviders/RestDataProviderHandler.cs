using Arboretum.Core.Enums;
using Arboretum.Core.Extensions;
using System.Collections.Generic;
using System.IO;

namespace Arboretum.Core.Helpers.DataProviders
{
    public static class RestDataProviderHandler
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <returns></returns>
        public static List<RestDataProvider> GetProviders( )
        {
            using ( StreamReader reader = new StreamReader( "D:\\Workspace\\virtual_arboretum\\core\\Arboretum\\Arboretum.Core\\config.json" ) )
            {
                string json = reader.ReadToEnd( );
                return json.DeserializeProviders( );
            }
        }

    
        public static RestDataProvider GetProvider( ProviderName providerName )
        {
            var providers = GetProviders( );
            return providers.Find( p => p.Name == providerName );
        }
    }
}
