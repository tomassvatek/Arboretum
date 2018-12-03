using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Enums;

namespace Arboretum.AppCore.Repositories
{
    public interface IRestRepository
    {
        Task<IList<ITree>> GetTreesAsync(IRegion region);
        //Task<IList<ITree>> GetClosestTreesAsync(IRegion region, )
        Task<ITree> GetTreeByIdAsync(int id, ProviderName providerName);
    }
}   