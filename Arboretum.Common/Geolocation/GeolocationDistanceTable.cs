using System.Collections.Generic;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.Common.Geolocation
{
    public class GeolocationDistanceTable<T> where T : IGeolocation 
    {       
        public List<GeolocationResult> GeolocationResults { get; set; } 

        public GeolocationDistanceTable()
        {
            GeolocationResults = new List<GeolocationResult>();
        }
            
        public List<GeolocationResult> Calculate(List<T> geolocationCollection, double latitude, double longitude)
        {
            GeolocationResults.Clear();

            foreach (var geolocationItem in geolocationCollection)  
            {
                var distance = HaverniseDistance.Calculate(latitude, longitude, geolocationItem.Latitude, geolocationItem.Longitude);
                GeolocationResults.Add(new GeolocationResult(geolocationItem, distance));
            }

            GeolocationResults.Sort();
            return GeolocationResults;
        }
    }
}