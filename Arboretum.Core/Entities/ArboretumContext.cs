using System;
using Arboretum.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Arboretum.Core.Models
{
    public partial class ArboretumContext : DbContext
    {
        public ArboretumContext( )
        {
        }

        public ArboretumContext( DbContextOptions<ArboretumContext> options )
            : base( options )
        {
        }

        public virtual DbSet<Dendrology> Dendrology { get; set; }
        public virtual DbSet<Tree> Tree { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            if ( !optionsBuilder.IsConfigured )
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer( "Server=(localdb)\\mssqllocaldb;Database=Arboretum;Trusted_Connection=True;" );
            }
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Dendrology>( entity =>
             {
                 entity.Property( e => e.CommonName ).IsRequired( );
             } );

            modelBuilder.Entity<Tree>( entity =>
             {
                 entity.Property( e => e.Latitude ).HasColumnName( "Latitude " );

                 entity.HasOne( d => d.Dendrology )
                     .WithMany( p => p.Tree )
                     .HasForeignKey( d => d.DendrologyId )
                     .OnDelete( DeleteBehavior.ClientSetNull )
                     .HasConstraintName( "FK_Dendrology" );
             } );
        }
    }
}
