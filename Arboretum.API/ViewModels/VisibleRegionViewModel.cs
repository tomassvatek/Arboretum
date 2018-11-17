using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.API.ViewModels
{
    public class VisibleRegionViewModel : IRegion
    {   
        public double LatitudeMin { get; set; }
        public double LatitudeMax { get; set; }
        public double LongitudeMin { get; set; }
        public double LongitudeMax { get; set; }
    }
}
