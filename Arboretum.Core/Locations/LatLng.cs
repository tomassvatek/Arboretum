using Newtonsoft.Json;

namespace Arboretum.Core.Locations
{
    public class LatLng
    {
        [JsonProperty( "lat" )]
        public double Lattitude { get; set; }
        [JsonProperty( "lon" )]
        public double Longitude  { get; set; }  
    }
}
