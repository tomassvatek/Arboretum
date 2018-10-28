using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Repositories
{
    public interface ITreeRepository
    {
        IList<Tree> GetTrees( IRegion region );
        IList<Tree> GetTrees( IRegion region, double latitude, double longitude, int count );
        Tree GetTreeById( int id );
        IList<Dendrology> GetDendrologies( );
        Dendrology GetDendrologyById( int id );
        Tree CreateTree( Tree tree );
        void UpdateTree( int id, Tree tree );
        void DeleteTree( int id );  
    }
}