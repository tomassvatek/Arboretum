using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.AppCore.Models.Interfaces
{
    public interface ITree : IGeolocation
    {
        int Id { get; set; }
        Dendrology Dendrology { get; set; }
        int? Age { get; set; }
        double? Height { get; set; }
        double? CrownSize { get; set; }
        double? TrunkSize { get; set; }
        string Note { get; set; }
        bool IsEditable { get; set; }
    }
}