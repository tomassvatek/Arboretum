using Arboretum.Core.Modules.Locations;
using Newtonsoft.Json;

namespace Arboretum.Core.Models.Entities
{
    public class Tree
    {
        public int Id { get; set; }
        [JsonProperty( "species_scientific_name" )]
        public string SpeciesScientificName { get; set; }
        [JsonProperty( "species_common_name" )]
        public string SpeciesCommonName { get; set; }
        [JsonProperty( "coordinates" )]
        public LatLng LatLng { get; set; }
        public int Age { get; set; }    
        public double Height { get; set; }
        public double TrunkSize { get; set; }
        public double CrownSize { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
    }
}
