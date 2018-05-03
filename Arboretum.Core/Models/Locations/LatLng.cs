using Newtonsoft.Json;

namespace Arboretum.Core.Models.Locations
{
    public class LatLng
    {
        [JsonProperty( "lat" )]
        public double Lattitude { get; set; }
        [JsonProperty( "lon" )]
        public double Longitude  { get; set; }  
    }
}
