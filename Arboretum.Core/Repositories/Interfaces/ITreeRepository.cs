using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Core.Models;
using Arboretum.Core.Models.Interfaces;

namespace Arboretum.Core.Repositories.Intefaces
{
    public interface ITreeRepository : IRepository<Tree>
    {
        //IEnumerable<Tree> GetTrees(IMapViewport viewport);
        //Tree GetTrees(QuizOption option, IMapViewport viewport);
        //Tree GetTreeById( int id );
    }
}
