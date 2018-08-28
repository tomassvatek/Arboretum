using Arboretum.Core.Models.Interfaces;
using Newtonsoft.Json;

namespace Arboretum.Core.WebServices
{
    public class TreeDto : ITree, IDendrology, IGeolocation
    {
        public int Id { get; set; }

        public int? Age { get; set; }

        public double? Height { get; set; }

        public double? CrownSize { get; set; }

        public double? TrunkSize { get; set; }

        public string Note { get; set; }

        [JsonProperty( PropertyName = "species_common_name" )]
        public string CommonName { get; set; }

        [JsonProperty( PropertyName = "species_scientific_name" )]
        public string ScientificName { get; set; }

        public string About { get; set; }

        [JsonProperty( PropertyName = "lat" )]
        public double Latitude { get; set; }

        [JsonProperty( PropertyName = "lon" )]
        public double Longitude { get; set; }
    }
}
