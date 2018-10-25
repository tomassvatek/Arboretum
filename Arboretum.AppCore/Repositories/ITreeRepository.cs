using System.Collections.Generic;
using Arboretum.AppCore.Models;

namespace Arboretum.AppCore.Repositories
{
    public interface ITreeRepository
    {
        IList<Tree> GetTrees( IMapViewport mapViewport );
        IList<Tree> GetTrees( IMapViewport viewport, double latitude, double longitude, int count );
        Tree GetTreeById( int id );
        IList<Dendrology> GetDendrologies( );
        Dendrology GetDendrologyById( int id );
        void CreateTree( Tree tree );
        void UpdateTree( int id, Tree tree );
        void DeleteTree( int id );
    }
}