using Arboretum.Common.Enums;

namespace Arboretum.Web.ViewModels
{
    public class TreeViewModel  
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? CrownSize { get; set; }
        public double? TrunkSize { get; set; }
        public string TreeNote { get; set; }    
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int DendrologyId { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string AboutDendrology { get; set; }

        public ProviderName ProviderId { get; set; }    
        public bool IsEditable { get; set; }
    }
}
