using System.Collections.Generic;
using Arboretum.Core.Models.Entities;

namespace Arboretum.Core.Modules.Locations
{
    public interface IDistanceCalculator
    {
        IEnumerable<TreeDistance> GetResults( LatLng current, IEnumerable<Tree> trees );
    }
}
