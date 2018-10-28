using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;

namespace Arboretum.AppCore.Services
{
    public interface ITreeService
    {
        Task<IList<Tree>> GetTreesAsync( IRegion mapViewport );
        Task<IList<Tree>> GetTrees( IRegion viewport, double latitude, double longitude, int count );
        Tree GetTreeById( int id );
        IList<Dendrology> GetDendrologies( );
        Dendrology GetDendrologyById( int id );
        void CreateTree( Tree tree );
        void UpdateTree( int id, Tree tree );
        void DeleteTree( int id );
    }
}