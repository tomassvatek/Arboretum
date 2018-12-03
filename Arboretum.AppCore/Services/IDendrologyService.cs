using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.AppCore.Models.Interfaces;
using Arboretum.Common.ServiceResults;

namespace Arboretum.AppCore.Services
{
    public interface IDendrologyService
    {
        ServiceResult<List<IDendrology>> GetDendrologies();
        ServiceResult<IList<IDendrology>> GetDendrologies(IReduction reduction);
        ServiceResult<IDendrology> GetDendrologyById(int id);
    }
}