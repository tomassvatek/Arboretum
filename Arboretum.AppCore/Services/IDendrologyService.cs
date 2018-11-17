using System.Collections.Generic;
using Arboretum.AppCore.Models;
using Arboretum.Common.ServiceResults;

namespace Arboretum.AppCore.Services
{
    public interface IDendrologyService
    {
        ServiceResult<List<Dendrology>> GetDendrologies();
        ServiceResult<Dendrology> GetDendrologyById(int id);
    }
}