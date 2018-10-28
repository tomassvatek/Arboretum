using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Models
{
    public class Location : IGeolocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}