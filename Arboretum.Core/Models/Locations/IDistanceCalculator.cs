using System.Collections.Generic;
using Arboretum.Core.Models.Entities;

namespace Arboretum.Core.Models.Locations
{
    public interface IDistanceCalculator
    {
        IEnumerable<TreeDistance> GetResults( LatLng current, IEnumerable<Tree> trees );
    }
}
