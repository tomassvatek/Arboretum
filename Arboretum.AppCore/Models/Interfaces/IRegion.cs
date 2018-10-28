namespace Arboretum.AppCore.Models.Interfaces
{
    public interface IRegion
    {
        double LatitudeMin { get; set; }
        double LatitudeMax { get; set; }
        double LongitudeMin { get; set; }
        double LongitudeMax { get; set; }
    }
}