using System;
using System.Threading.Tasks;
using Arboretum.WebService;
using Arboretum.WebService.HttpClient;

namespace Arboretum.Console
{
    class Program
    {
        static async Task Main()
        {
            var restService = new RestRepository(new RestClient());
            var trees = await restService.GetTreesAsync(new Region
            {
                LatitudeMin = 49.795380,
                LatitudeMax = 49.797345,
                LongitudeMin = 12.633100,
                LongitudeMax = 12.634210
            });

            foreach (var tree in trees)
            {
                System.Console.WriteLine($"{tree.Dendrology.CommonName} {tree.Dendrology.ScientificName} {tree.Height}");
            }

            System.Console.ReadKey();   
        }
    }
}
