using System;
using Arboretum.Common.Extensions;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.Common.Geolocation
{
    public class HaverniseDistance : IDistanceCalculator
    {   
        public double CalculateDistance(IGeolocation origin, IGeolocation target)
        {
            var r = 6372.8;

            var originLat = origin.Latitude.ToRadians();
            var destinationLat = target.Latitude.ToRadians();

            var dLat = (target.Latitude - origin.Latitude).ToRadians();
            var dLon = (target.Longitude - origin.Longitude).ToRadians();

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(originLat) * Math.Cos(destinationLat);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return r * 2 * Math.Asin(Math.Sqrt(a)) / 1000;
        }
    }
}