using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Geolocation.Interfaces;

namespace Arboretum.AppCore.Repositories
{
    public interface ITreeRepository
    {
        IList<ITree> GetTrees(IRegion region);
        //IList<Tree> GetClosestTrees( IRegion region, double latitude, double longitude, int count );          
        ITree GetTreeById(int id);  
        ITree CreateTree(Tree tree);
        void UpdateTree(int id, Tree tree);
    }
}