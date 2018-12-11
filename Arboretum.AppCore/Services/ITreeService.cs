using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.Enums;
using Arboretum.Common.ServiceResults;

namespace Arboretum.AppCore.Services
{
    public interface ITreeService
    {
        Task<ServiceResult<IList<ITree>>> GetTreesAsync(IRegion region);

        Task<ServiceResult<ITree>> GetTreeById(int id, ProviderName providerName);

        Task<ServiceResult<IList<ITree>>> GetClosestTreesAsync(IRegion region, double latitude, 
                                                                 double longitude, int? count);
        Task<ServiceResult<ITree>> GetClosestTree(IRegion region, double latitude, 
                                             double longitude, string commonName);              
        
        ServiceResult<ITree> CreateTree(Tree tree);     

        ServiceResult UpdateTree(int id, Tree tree);
    }   
}