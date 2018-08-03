using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arboretum.Core.Services
{
    public interface ITreeService
    {
        IEnumerable<Tree> GetTrees( );
        IEnumerable<Tree> GetTrees( IMapViewport mapViewport );

        Tree GetTrees( IMapViewport viewport, LatLng currentLocation, int count );
        Tree GetTree( int id );
    }
}
