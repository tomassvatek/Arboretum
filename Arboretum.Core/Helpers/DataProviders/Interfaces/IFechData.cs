using Arboretum.Core.Helpers.DataProviders;
using Arboretum.Core.Models;
using Arboretum.Core.Models.Interfaces;
using Arboretum.Core.Modules.Locations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Arboretum.Core.Helpers.DataProviders.Interfaces
{
    public interface IFechData
    {
        Task<List<Tree>> FetchDataAsync( IMapViewport viewport );
    }
}
