using Arboretum.Core.Models.Locations;

namespace Arboretum.API.Viewmodels
{
    public class TreeDetailVm   
    {
        public int Id { get; set; }
        public string SpeciesScientificName { get; set; }
        public string SpeciesCommonName { get; set; }
        public LatLng LatLng { get; set; }
        public string About { get; set; }
        public byte[] Image { get; set; }
    }
}
