
namespace Arboretum.Core.Models.Locations
{
    public class MapViewport : IMapViewport
    {
        public LatLng NorthWest { get; set; }
        public LatLng NorthEast { get; set; }
        public LatLng SouthEast { get; set; }
        public LatLng SouthWest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapViewport"/> class.
        /// </summary>
        /// <param name="latitudeMin">The latitude of bottom left corner.</param>
        /// <param name="latitudeMax">The latitude of top right corner.</param>
        /// <param name="longitudeMin">The longitude of bottom left corner.</param>
        /// <param name="longitudeMax">The longitude of top right corner.</param>
        public MapViewport( double latitudeMin, double latitudeMax, double longitudeMin, double longitudeMax )
        {
            NorthEast = new LatLng( latitudeMax, longitudeMax );
            SouthWest = new LatLng( latitudeMin, longitudeMin );
            NorthWest = new LatLng( latitudeMin, longitudeMax );
            SouthEast = new LatLng( latitudeMax, longitudeMin );
        }


        ///// <summary>
        ///// Initializes a new instance of the <see cref="MapViewport"/> class.
        ///// </summary>
        ///// <param name="northEast">The top right corner.</param>
        ///// <param name="southWest">The bottom left corner.</param>
        //public MapViewport( LatLng northEast, LatLng southWest)
        //{
        //    NorthEast = northEast;
        //    SouthWest = southWest;
        //    NorthWest.Latitude = southWest.Latitude;
        //    NorthWest.Longitude = northEast.Longitude;
        //    SouthEast.Latitude = northEast.Latitude;
        //    SouthEast.Longitude = southWest.Longitude;

        //}

        //public MapViewport(LatLng northWest, LatLng northEast, LatLng southEast, LatLng southWest )
        //{
        //    NorthWest = northWest;
        //    NorthEast = northEast;
        //    SouthEast = southEast;
        //    SouthWest = southWest;
        //}
    }
}
