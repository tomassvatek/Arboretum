using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.AppCore.Repositories
{
    public interface ITreeRepository
    {
        IList<Tree> GetTrees(IRegion region);
        //IList<Tree> GetClosestTrees( IRegion region, double latitude, double longitude, int count );          
        Tree GetTreeById(int id);
        Tree CreateTree(Tree tree);
        void UpdateTree(int id, Tree tree);
        //void DeleteTree( int id );  
    }
}