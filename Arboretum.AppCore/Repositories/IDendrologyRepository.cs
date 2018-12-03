using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;

namespace Arboretum.AppCore.Repositories
{
    public interface IDendrologyRepository
    {
        IList<IDendrology> GetDendrologies();
        IList<IDendrology> GetDendrologies(IReduction reduction);
        IDendrology GetDendrologyById(int id);
    }
}