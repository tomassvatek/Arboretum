
using Arboretum.Core.Models.Interfaces;

namespace Arboretum.Core.Modules.Locations
{
    /// <summary>
    /// The inteface represents a visibile region. 
    /// The map viewport depends on user's current location.
    /// </summary>
    public interface IMapViewport
    {
        LatLng TopLeft { get; set; }
        LatLng TopRight { get; set; }
        LatLng BottomRight { get; set; }
        LatLng BottomLeft { get; set; }

        /// <summary>
        /// Includes the specified geolocation.
        /// </summary>
        /// <param name="geolocation">The geolocation.</param>
        /// <returns></returns>
        bool Include( IGeolocation geolocation );
    }
}
    