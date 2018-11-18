using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common;
using Arboretum.Common.Enums;

namespace Arboretum.WebService.Providers.Interfaces
{
    public interface ITreeDataProvider
    {
        ProviderName Name { get; }
        string BaseAddress { get; }
        bool IsEditable { get; }
        IList<RequestHeaders> RequestHeaders { get; set; }  
        Task<IList<ITree>> GetTreesAsync(IRegion region);
        Task<ITree> GetTreeByIdAsync(int id);
    }
}