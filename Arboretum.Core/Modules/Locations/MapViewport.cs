using Arboretum.Core.Models.Interfaces;

namespace Arboretum.Core.Modules.Locations
{
    public class MapViewport : IMapViewport
    {
        public LatLng TopLeft { get; set; }
        public LatLng TopRight { get; set; }
        public LatLng BottomRight { get; set; }
        public LatLng BottomLeft { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapViewport"/> class.
        /// </summary>
        /// <param name="latitudeMin">The latitude of bottom left corner.</param>
        /// <param name="latitudeMax">The latitude of top right corner.</param>
        /// <param name="longitudeMin">The longitude of bottom left corner.</param>
        /// <param name="longitudeMax">The longitude of top right corner.</param>
        public MapViewport( double latitudeMin, double latitudeMax, double longitudeMin, double longitudeMax )
        {
            TopRight = new LatLng( latitudeMax, longitudeMax );
            BottomLeft = new LatLng( latitudeMin, longitudeMin );
            TopLeft = new LatLng( latitudeMin, longitudeMax );
            BottomRight = new LatLng( latitudeMax, longitudeMin );
        }

        public MapViewport( )
        {

        }

        /// <summary>
        /// Includes the specified geolocation.
        /// </summary>
        /// <param name="geolocation">The geolocation.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Include( IGeolocation geolocation )
        {
            return ((TopLeft.Latitude < geolocation.Latitude && BottomRight.Latitude > geolocation.Latitude) && (TopLeft.Longitude < geolocation.Longitude && BottomRight.Longitude > geolocation.Longitude));
        }
    }
}
