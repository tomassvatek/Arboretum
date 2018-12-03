﻿// <auto-generated />
using System;
using Arboretum.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arboretum.Persistence.Migrations
{
    [DbContext(typeof(ArboretumDbContext))]
    partial class ArboretumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arboretum.Persistence.Entities.Dendrology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About");

                    b.Property<string>("CommonName")
                        .IsRequired();

                    b.Property<string>("ScientificName");

                    b.HasKey("Id");

                    b.ToTable("Dendrologies");

                    b.HasData(
                        new { Id = 1, CommonName = "Bříza", ScientificName = "bříza latinsky" },
                        new { Id = 2, CommonName = "Buk", ScientificName = "buk latinsky" }
                    );
                });

            modelBuilder.Entity("Arboretum.Persistence.Entities.Tree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age");

                    b.Property<double?>("CrownSize");

                    b.Property<int>("DendrologyId");

                    b.Property<double?>("Height");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Note");

                    b.Property<double?>("TrunkSize");

                    b.HasKey("Id");

                    b.HasIndex("DendrologyId");

                    b.ToTable("Trees");

                    b.HasData(
                        new { Id = 1, Age = 50, CrownSize = 20.0, DendrologyId = 1, Latitude = 49.53313, Longitude = 14.80902 },
                        new { Id = 2, Age = 80, CrownSize = 20.0, DendrologyId = 2, Latitude = 49.53314, Longitude = 14.80903 },
                        new { Id = 3, Age = 90, CrownSize = 208.0, DendrologyId = 2, Latitude = 49.53304, Longitude = 14.809039 },
                        new { Id = 4, Age = 90, CrownSize = 208.0, DendrologyId = 1, Latitude = 49.53304, Longitude = 14.809039 }
                    );
                });

            modelBuilder.Entity("Arboretum.Persistence.Entities.Tree", b =>
                {
                    b.HasOne("Arboretum.Persistence.Entities.Dendrology", "Dendrology")
                        .WithMany("Tree")
                        .HasForeignKey("DendrologyId");
                });
#pragma warning restore 612, 618
        }
    }
}