
namespace Arboretum.Core.Models.Locations
{
    /// <summary>
    /// The inteface represents a map viewport. It is what a user sees. 
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
