using System;
using System.Threading.Tasks;
using Arboretum.Common.Geolocation;
using Arboretum.WebService;
using Arboretum.WebService.HttpClient;

namespace Arboretum.Console
{
    class Program
    {
        static async Task Main()
        {
            //var restService = new RestRepository(new RestClient());
            //var trees = await restService.GetTreesAsync(new Region
            //{
            //    LatitudeMin = 49.795380,
            //    LatitudeMax = 49.797345,
            //    LongitudeMin = 12.633100,
            //    LongitudeMax = 12.634210
            //});

            //foreach (var tree in trees)
            //{
            //    System.Console.WriteLine($"{tree.Dendrology.CommonName} {tree.Dendrology.ScientificName} {tree.Height}");
            //}

            double latTarget = 49.797124501;
            double lonTarget = 12.6340582315;

            // Current location
            double originLat = 49.797345;
            double originLon = 12.634210;
            var result = HaverniseDistance.Calculate(originLat, originLon, latTarget, lonTarget);
            System.Console.WriteLine(result);
            System.Console.ReadKey();   
        }
    }
}
