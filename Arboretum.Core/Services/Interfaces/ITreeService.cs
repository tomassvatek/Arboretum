using Arboretum.Core.Entities;
using Arboretum.Core.Helpers.Locations;
using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arboretum.Core.Services.Interfaces
{
    public interface ITreeService
    {
        Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport mapViewport );
        Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport viewport, LatLng currentLocation, int count );
        Tree GetTree( int id );
        Dendrology GetDendrology( int id );
        bool Create( Tree tree );
        bool Edit( int id, Tree tree );
    }
}
