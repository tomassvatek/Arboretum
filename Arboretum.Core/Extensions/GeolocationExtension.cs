using Arboretum.Core.Models.Interfaces;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;

namespace Arboretum.Core.Extensions
{
    public static class GeolocationExtension
    {
        /// <summary>
        /// Calculates the geolocation distance (Havernise formula).
        /// </summary>
        /// <param name="origin">The origin.</param>
        /// <param name="destination">The destination.</param>
        /// <returns></returns>
        public static double CalculateGeolocationDistance( this IGeolocation origin, LatLng destination )
        {
            var r = 6372.8;

            // convert to radians
            var originLat = origin.Latitude.ToRadians();
            var destinationLat = destination.Latitude.ToRadians();

            var dLat = (destination.Latitude - origin.Latitude).ToRadians();
            var dLon = (destination.Longitude - origin.Longitude).ToRadians();

            // computation
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(originLat) * Math.Cos(destinationLat);
            var c = 2 * Math.Asin(Math.Sqrt(a));
            return r * 2 * Math.Asin( Math.Sqrt( a ) ) / 1000;
        }
    }

    public class GeolocationDataTable
    {
        public List<GeolocationResult> DataTable { get; set; } = new List<GeolocationResult>( );
    }

    public class GeolocationResult
    {
        public double Distance { get; set; }
        public IGeolocation Geolocation { get; set; }
    }
}
