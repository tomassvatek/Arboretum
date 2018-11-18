using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.Common.Geolocation
{
    public class Location : IGeolocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location()
        {
        }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}