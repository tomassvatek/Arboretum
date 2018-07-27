using Arboretum.Core.Modules.Locations;

namespace Arboretum.API.Viewmodels
{
    public class TreeDetailViewModel   
    {
        public int Id { get; set; } 
        public string SpeciesScientificName { get; set; }
        public string SpeciesCommonName { get; set; }   
        public LatLng LatLng { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
    }
}
