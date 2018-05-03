
namespace Arboretum.Core.Models.Locations
{
    public class MapViewport : IMapViewport
    {
        public double NorthWest { get; set; }
        public double NorthEast { get; set; }
        public double SouthEast { get; set; }
        public double SouthWest { get; set; }
    }
}
