﻿
namespace Arboretum.Core.Modules.Locations
{
    /// <summary>
    /// The inteface represents a visibile region. 
    /// The map viewport depends on user's current location.
    /// </summary>
    public interface IMapViewport
    {
        // Top left corner
        LatLng NorthWest { get; set; }
        // Top right corner
        LatLng NorthEast { get; set; }
        // Bottom right corner
        LatLng SouthEast { get; set; }
        // Bottom left corner
        LatLng SouthWest { get; set; }
    }
}
