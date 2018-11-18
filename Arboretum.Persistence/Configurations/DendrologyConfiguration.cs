using Arboretum.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arboretum.Persistence.Configurations
{
    public class DendrologyConfiguration : IEntityTypeConfiguration<Dendrology>
    {
        public void Configure( EntityTypeBuilder<Dendrology> builder )
        {
            builder.HasKey( e => e.Id );
            builder.Property( e => e.CommonName ).IsRequired( );
        }
    }
}