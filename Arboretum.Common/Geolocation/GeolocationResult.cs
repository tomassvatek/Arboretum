using System;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.Common.Geolocation
{
    public class GeolocationResult : IComparable<GeolocationResult>
    {
        public IGeolocation Geolocation { get; set; }
        public double Distance { get; set; }

        public GeolocationResult(IGeolocation geolocation, double distance)
        {
            Geolocation = geolocation;
            Distance = distance;
        }

        public int CompareTo(GeolocationResult other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}