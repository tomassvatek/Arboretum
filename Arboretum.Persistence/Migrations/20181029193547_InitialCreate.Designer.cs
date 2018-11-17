﻿// <auto-generated />

namespace Arboretum.Persistence.Migrations
{
    [DbContext(typeof(ArboretumDbContext))]
    [Migration("20181029193547_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
