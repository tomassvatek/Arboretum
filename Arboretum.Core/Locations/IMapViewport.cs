using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Locations
{
    public interface IMapViewport
    {
        LatLng NorthWest { get; set; }
        LatLng NorthEast { get; set; }
        LatLng SouthEast { get; set; }
        LatLng SouthWest { get; set; }
    }
}
