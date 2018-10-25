
using Arboretum.Core.Entities.Interfaces;

namespace Arboretum.Core.Entities
{
    public partial class Tree : ITree   
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? CrownSize { get; set; }
        public double? TrunkSize { get; set; }
        public string Note { get; set; }
        public int DendrologyId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Dendrology Dendrology { get; set; }
    }
}
