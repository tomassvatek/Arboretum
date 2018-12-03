using System.Collections.Generic;
using System.Linq;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.Common.Geolocation
{
    public class GeolocationDistanceTable<T> where T : IGeolocation
    {
        private readonly List<GeolocationResult> _geolocationResults;

        public GeolocationDistanceTable()
        {
            _geolocationResults = new List<GeolocationResult>();
        }
            
        public List<GeolocationResult> Calculate(IList<T> geolocationCollection, double latitude, double longitude)
        {
            _geolocationResults.Clear();

            foreach (var geolocationItem in geolocationCollection)  
            {
                var distance = HaverniseDistance.Calculate(latitude, longitude, geolocationItem.Latitude, geolocationItem.Longitude);
                _geolocationResults.Add(new GeolocationResult(geolocationItem, distance));
            }

            _geolocationResults.Sort();
            return _geolocationResults;
        }
    }
}