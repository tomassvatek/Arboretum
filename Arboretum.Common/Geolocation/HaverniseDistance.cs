using System;
using Arboretum.Common.Extensions;

namespace Arboretum.Common.Geolocation
{
    public static class HaverniseDistance   
    {   
        public static double Calculate(double originLat, double originLon, 
                                       double targetLat, double targetLon)
        {   
            var r = 6372.8;

            var latOrigin = originLat.ToRadians(); 
            var latDestination = targetLat.ToRadians();

            var dLat = (targetLat - originLat).ToRadians();
            var dLon = (targetLon - originLon).ToRadians();

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + 
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * 
                    Math.Cos(latOrigin) * Math.Cos(latDestination);

            return r * 2 * Math.Asin(Math.Sqrt(a)) / 1000;
        }
    }
}