using Newtonsoft.Json;

namespace Arboretum.Core.Modules.Locations
{
    public class LatLng
    {
        [JsonProperty( "lat" )]
        public double Latitude { get; set; }
        [JsonProperty( "lon" )]
        public double Longitude  { get; set; }

        public LatLng( ) { }
        public LatLng(double latitude, double longitude )
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
