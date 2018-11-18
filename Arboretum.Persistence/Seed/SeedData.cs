using Arboretum.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arboretum.Persistence.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Dendrology>().HasData(
                new Dendrology { Id = 1, CommonName = "Bříza", ScientificName = "bříza latinsky" },
                new Dendrology { Id = 2, CommonName = "Buk", ScientificName = "buk latinsky" }
            );

            modelBuilder.Entity<Tree>().HasData(
                new Tree() { Id = 1, Age = 50, CrownSize = 20, DendrologyId = 1, Latitude = 49.533130, Longitude = 14.809020 },
                new Tree() { Id = 2, Age = 80, CrownSize = 20, DendrologyId = 2, Latitude = 49.533140, Longitude = 14.809030 },
                new Tree() { Id = 3, Age = 90, CrownSize = 208, DendrologyId = 2, Latitude = 49.533040, Longitude = 14.809039 },
                new Tree() { Id = 4, Age = 90, CrownSize = 208, DendrologyId = 1, Latitude = 48.533040, Longitude = 12.809039 },
                new Tree() { Id = 5, Age = 90, CrownSize = 208, DendrologyId = 1, Latitude = 49.533040, Longitude = 11.809039 }
            );
        }
    }
}