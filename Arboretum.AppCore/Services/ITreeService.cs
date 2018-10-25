using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;

namespace Arboretum.AppCore.Services
{
    public interface ITreeService
    {
        IList<Tree> GetTrees( IMapViewport mapViewport );
        IList<Tree> GetTrees( IMapViewport viewport, double latitude, double longitude, int count );
        Tree GetTreeById( int id );
        IList<Dendrology> GetDendrologies();
        Dendrology GetDendrologyById( int id ); 
        void CreateTree( Tree tree );
        void UpdateTree( int id, Tree tree );
        void DeleteTree(int id);
    }
}