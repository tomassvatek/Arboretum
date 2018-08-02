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
        Tree GetTrees( IMapViewport viewport, LatLng currentLocation, int count );
        Tree GetTreeById( int id );
    }
}
