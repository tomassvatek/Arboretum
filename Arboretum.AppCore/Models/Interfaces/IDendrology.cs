namespace Arboretum.AppCore.Models.Interfaces
{
    public interface IDendrology
    {
        int Id { get; set; }
        string CommonName { get; set; }
        string ScientificName { get; set; }
        string About { get; set; }
    }
}