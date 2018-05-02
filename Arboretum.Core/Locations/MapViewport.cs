using Arboretum.Core.Helpers;

namespace Arboretum.Core.Locations
{
    public class MapViewport
    {
        public LatLng NorthWest { get; set; }
        public LatLng NorthEast { get; set; }
        public LatLng SouthEast { get; set; }
        public LatLng SouthWest { get; set; }
    }
}
