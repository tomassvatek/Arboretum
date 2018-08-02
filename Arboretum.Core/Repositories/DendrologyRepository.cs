using Arboretum.Core.Models;

namespace Arboretum.Core.Repositories
{
    public class DendrologyRepository : Repository<Dendrology>, IDendrologyRepository
    {
        public DendrologyRepository( ArboretumContext context ) : base( context )
        {

        }
    }
}
