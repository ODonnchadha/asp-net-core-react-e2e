﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Contexts;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(HouseDbContext))]
    partial class HouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("api.Entities.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Coutry")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "100 Duluth Street, DULUTH, Minnesota",
                            Coutry = "US",
                            Description = "Acceptable house. Somewhat nifty.",
                            Price = 200000
                        },
                        new
                        {
                            Id = 2,
                            Address = "40 Superior Street, SUPERIOR, Wisconsin",
                            Coutry = "US",
                            Description = "Dog food. Unacceptable.",
                            Price = 400
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
