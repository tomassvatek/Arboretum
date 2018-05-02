using Arboretum.Core.Helpers;

namespace Arboretum.Core.Models
{
    public class Tree
    {
        public int Id { get; set; }
        public string SpeciesScientificName { get; set; }
        public string SpeciesCommonName { get; set; }
        public LatLng LatLng { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }   
    }
}
