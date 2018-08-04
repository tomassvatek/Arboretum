using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arboretum.Core.Services
{
    public interface ITreeService
    {
        Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport mapViewport );
        Task<IEnumerable<Tree>> GetTreesAsync( IMapViewport viewport, LatLng currentLocation, int count );
        Tree GetTree( int id );
        Dendrology GetDendrology( int id );
    }
}
