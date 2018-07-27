using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Core.Models;
using Arboretum.Core.Modules.Locations;

namespace Arboretum.Core.Repositories
{
    public interface ITreeRepository : IRepository<Tree>
    {
        //IEnumerable<Tree> GetTrees(IMapViewport viewport);
        //Tree GetTrees(QuizOption option, IMapViewport viewport);
        //Tree GetTreeById( int id );
    }
}
