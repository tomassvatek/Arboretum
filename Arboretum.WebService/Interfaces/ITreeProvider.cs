using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.WebService.Providers;

namespace Arboretum.WebService.Interfaces
{
    public interface ITreeProvider
    {
        ProviderName Name { get; }  
        string BaseAddress { get; }
        Task<IList<Tree>> GetTrees( IMapViewport mapViewport );
    }
}