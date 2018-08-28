using Arboretum.Core.Helpers.Locations.Interfaces;
using Arboretum.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arboretum.Core.Helpers.DataProviders.Interfaces
{
    public interface IFechData
    {
        Task<List<Tree>> FetchDataAsync( IMapViewport viewport );
    }
}
