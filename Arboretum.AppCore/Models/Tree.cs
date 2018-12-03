using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Enums;

namespace Arboretum.AppCore.Models
{
    public class Tree : ITree, IProvider
    {   
        public int Id { get; set; }
        public IDendrology Dendrology { get; set; }  
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? CrownSize { get; set; }
        public double? TrunkSize { get; set; }
        public string Note { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ProviderName ProviderName { get; set; }
        public bool IsEditable { get; set; }
    }
}