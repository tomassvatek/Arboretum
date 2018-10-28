using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Repositories
{
    public interface IRestRepository
    {
        Task<IList<Tree>> GetTreesAsync( IRegion region );  
    }
}