using Arboretum.Persistence.Configurations;
using Arboretum.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arboretum.Persistence
{
    public class ArboretumDbContext : DbContext
    {
        public ArboretumDbContext( DbContextOptions options ) : base( options )
        {

        }

        public virtual DbSet<Dendrology> Dendrology { get; set; }
        public virtual DbSet<Tree> Tree { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.ApplyConfiguration( new TreeConfiguration( ) );    
            modelBuilder.ApplyConfiguration( new DendrologyConfiguration( ) );

            base.OnModelCreating( modelBuilder );
        }
    }
}