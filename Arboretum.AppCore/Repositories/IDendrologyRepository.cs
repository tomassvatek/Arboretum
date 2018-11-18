using System.Collections.Generic;
using Arboretum.AppCore.Models;

namespace Arboretum.AppCore.Repositories
{
    public interface IDendrologyRepository
    {
        IList<Dendrology> GetDendrologies();
        Dendrology GetDendrologyById(int id);
    }
}