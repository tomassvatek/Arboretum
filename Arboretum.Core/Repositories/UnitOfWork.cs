using Arboretum.Core.Models;

namespace Arboretum.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArboretumContext _context;

        public UnitOfWork( ArboretumContext context )
        {
            _context = context;
            Trees = new TreeRepository( _context );
            Dendrologies = new DendrologyRepository( _context );
        }

        public ITreeRepository Trees { get; set; }
        public IDendrologyRepository Dendrologies { get; set; }

        public int SaveChanges( )
        {
            return _context.SaveChanges( );
        }

        public void Dispose( )
        {
            _context.Dispose( );
        }
    }
}
