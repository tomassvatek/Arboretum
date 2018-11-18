namespace Arboretum.Common.Geolocation.Interfaces
{
    public interface IDistanceCalculator
    {
        double CalculateDistance( IGeolocation origin, IGeolocation target );   
    }
}