using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;

namespace Arboretum.Console
{
    public class Region : IRegion
    {
        public double LatitudeMin { get; set; }
        public double LatitudeMax { get; set; }
        public double LongitudeMin { get; set; }
        public double LongitudeMax { get; set; }
    }
}