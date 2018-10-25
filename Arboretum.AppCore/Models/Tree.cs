namespace Arboretum.AppCore.Models
{
    public class Tree
    {   
        public int Id { get; set; }
        public Dendrology Dendrology { get; set; }  
        public Location Location { get; set; }  
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? CrownSize { get; set; }
        public double? TrunkSize { get; set; }
        public string Note { get; set; }
    }
}