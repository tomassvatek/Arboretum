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
        Task<ServiceResult<List<Tree>>> GetTreesAsync(IRegion region);
        Task<ServiceResult<Tree>> GetTreeById(int id, ProviderName providerName);
        Task<ServiceResult<List<Tree>>> GetClosestTreesAsync(IRegion region, double latitude, double longitude, int count);
        //Task<ServiceResult<Tree>> GetClosestTree(int id, ProviderName providerName);    
        ServiceResult<Tree> CreateTree(Tree tree);  
        ServiceResult UpdateTree(int id, Tree tree);
    }   
}