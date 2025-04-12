﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ValueConversions.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender2")
                        .HasColumnType("int");

                    b.Property<bool>("Married")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = "M",
                            Gender2 = 0,
                            Married = true,
                            Name = "Serhat"
                        },
                        new
                        {
                            Id = 2,
                            Gender = "M",
                            Gender2 = 0,
                            Married = false,
                            Name = "Kamil"
                        },
                        new
                        {
                            Id = 3,
                            Gender = "M",
                            Gender2 = 0,
                            Married = true,
                            Name = "Cemil"
                        },
                        new
                        {
                            Id = 4,
                            Gender = "M",
                            Gender2 = 0,
                            Married = true,
                            Name = "Boran"
                        },
                        new
                        {
                            Id = 5,
                            Gender = "F",
                            Gender2 = 1,
                            Married = false,
                            Name = "Selin"
                        },
                        new
                        {
                            Id = 6,
                            Gender = "F",
                            Gender2 = 1,
                            Married = false,
                            Name = "Şeyma"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
