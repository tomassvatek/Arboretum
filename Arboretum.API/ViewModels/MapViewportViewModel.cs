using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arboretum.API.Viewmodels
{
    public class MapViewportViewModel
    {
        // Latitude of bottom left corner
        public double LatitudeMin { get; set; }
        // Latitude of top right corner
        public double LatitudeMax { get; set; }
        // Longitude of bottom left corner
        public double LongitudeMin { get; set; }
        // Longitude of top right corner
        public double LongitudeMax { get; set; }
    }
}
