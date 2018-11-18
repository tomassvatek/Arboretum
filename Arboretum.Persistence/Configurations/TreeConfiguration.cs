using Arboretum.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arboretum.Persistence.Configurations
{
    public class TreeConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure( EntityTypeBuilder<Tree> builder )
        {
            builder.HasKey( t => t.Id );
            builder.HasOne( d => d.Dendrology )
                .WithMany( t => t.Tree )
                .HasForeignKey( d => d.DendrologyId )
                .OnDelete( DeleteBehavior.ClientSetNull );
        }
    }
}