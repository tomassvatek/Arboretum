using Arboretum.Core.Helpers.DataProviders;
using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main( string[] args )
        {
            IMapViewport viewport = new MapViewport(49.795380, 49.797345, 12.633100, 12.634210 );
            var providers = RestDataProviderHandler.GetProviders( );

            foreach ( var item in providers )
            {
                var content = item.FetchDataAsync( viewport );
            }

            Console.ReadKey( );
        }

    }
}
