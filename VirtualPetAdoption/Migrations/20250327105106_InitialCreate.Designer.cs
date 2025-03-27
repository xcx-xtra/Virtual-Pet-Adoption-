﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualPetAdoption.Data;

#nullable disable

namespace VirtualPetAdoption.Migrations
{
    [DbContext(typeof(PetAdoptionContext))]
    [Migration("20250327105106_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("VirtualPetAdoption.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Affection")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Playfulness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Affection = 5,
                            Description = "A playful and affectionate cat.",
                            ImageUrl = "/images/cat.png",
                            Name = "Fluffy",
                            Playfulness = 4,
                            Species = "Cat"
                        },
                        new
                        {
                            Id = 2,
                            Affection = 4,
                            Description = "An energetic dog who loves to play.",
                            ImageUrl = "/images/dog.png",
                            Name = "Rex",
                            Playfulness = 5,
                            Species = "Dog"
                        },
                        new
                        {
                            Id = 3,
                            Affection = 3,
                            Description = "A quiet and independent cat.",
                            ImageUrl = "/images/cat2.png",
                            Name = "Whiskers",
                            Playfulness = 2,
                            Species = "Cat"
                        });
                });

            modelBuilder.Entity("VirtualPetAdoption.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AdoptedPetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PreferredAffection")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PreferredPlayfulness")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AdoptedPetId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("VirtualPetAdoption.Models.User", b =>
                {
                    b.HasOne("VirtualPetAdoption.Models.Pet", "AdoptedPet")
                        .WithMany()
                        .HasForeignKey("AdoptedPetId");

                    b.Navigation("AdoptedPet");
                });
#pragma warning restore 612, 618
        }
    }
}
