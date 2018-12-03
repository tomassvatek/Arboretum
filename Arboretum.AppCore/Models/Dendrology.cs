using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Models
{
    public class Dendrology : IDendrology
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string About { get; set; }
    }
}