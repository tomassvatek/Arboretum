using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.Core.Models.Entities;
using Arboretum.Core.Models.Locations;

namespace Arboretum.Core.Repositories
{
    public interface ITreeRepository
    {
        Task<IEnumerable<Tree>> GetTrees(IMapViewport viewport);
        Tree GetTrees(QuizOption option, IMapViewport viewport);
        Tree GetTreeById( int id );
    }
}
