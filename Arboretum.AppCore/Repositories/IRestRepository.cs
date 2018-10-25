using System.Collections.Generic;
using Arboretum.AppCore.Models;

namespace Arboretum.AppCore.Repositories
{
    public interface IRestRepository
    {
        IList<Tree> GetTrees( IMapViewport mapViewport );
    }
}