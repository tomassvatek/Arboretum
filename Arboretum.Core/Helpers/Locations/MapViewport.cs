using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models.Interfaces;

namespace Arboretum.Core.Helpers.Locations  
{
    public class MapViewport : IMapViewport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapViewport"/> class.
        /// </summary>
        /// <param name="latitudeMin">The latitude minimum.</param>
        /// <param name="latitudeMax">The latitude maximum.</param>
        /// <param name="longitudeMin">The longitude minimum.</param>
        /// <param name="longitudeMax">The longitude maximum.</param>
        public MapViewport( double latitudeMin, double latitudeMax, double longitudeMin, double longitudeMax )
        {
            this.LatitudeMin = latitudeMin;
            this.LatitudeMax = latitudeMax;
            this.LongitudeMin = longitudeMin;
            this.LongitudeMax = longitudeMax;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapViewport"/> class.
        /// </summary>
        public MapViewport( )
        {
        }

        public double LatitudeMin { get; set; }
        public double LatitudeMax { get; set; }
        public double LongitudeMin { get; set; }
        public double LongitudeMax { get; set; }


        /// <summary>
        /// Includes the specified geolocation.
        /// </summary>
        /// <param name="geolocation">The geolocation.</param>
        /// <returns></returns>
        public bool Include( IGeolocation geolocation )
        {
            return ((this.LatitudeMin < geolocation.Latitude && this.LatitudeMax > geolocation.Latitude) && (this.LongitudeMin < geolocation.Longitude && this.LongitudeMax > geolocation.Longitude));
        }
    }
}
