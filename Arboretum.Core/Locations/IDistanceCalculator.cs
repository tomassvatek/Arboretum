using System;
using System.Collections.Generic;
using Arboretum.Core.Helpers;
using Arboretum.Core.Models;

namespace Arboretum.Core.Locations
{
    public interface IDistanceCalculator
    {
        IEnumerable<TreeDistance> GetResults( LatLng current, IEnumerable<Tree> trees );
    }
}
