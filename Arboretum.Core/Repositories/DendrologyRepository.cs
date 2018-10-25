using Arboretum.Core.Entities;
using Arboretum.Core.Models;
using Arboretum.Core.Repositories.Intefaces;

namespace Arboretum.Core.Repositories
{
    public class DendrologyRepository : Repository<Dendrology>, IDendrologyRepository
    {
        public DendrologyRepository( ArboretumContext context ) : base( context )
        {

        }
    }
}
