using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.AppCore.Repositories;
using Arboretum.Common;

namespace Arboretum.WebService.Providers.Interfaces
{
    public interface ITreeDataProvider
    {
        ProviderName Name { get; }
        string BaseAddress { get; }
        bool IsEditable { get; }
        IList<RequestHeaders> RequestHeaders { get; set; }
        Task<IList<Tree>> GetTreesAsync( IRegion region );
    }
}