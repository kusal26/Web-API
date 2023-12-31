﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Webapi1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230814033432_addedcollection")]
    partial class addedcollection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webapi1.Models.BookedMOdel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HallName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Noofticket")
                        .HasColumnType("int");

                    b.Property<int?>("PricePerEach")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Showdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime?>("bookeddate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BookedModels");
                });

            modelBuilder.Entity("Webapi1.Models.MovieHall", b =>
                {
                    b.Property<int>("HallId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HallId"));

                    b.Property<string>("HallLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HallName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeat")
                        .HasColumnType("int");

                    b.HasKey("HallId");

                    b.ToTable("MovieHall");
                });

            modelBuilder.Entity("Webapi1.Models.Movies", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Cast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Webapi1.Models.ShowTiming", b =>
                {
                    b.Property<int>("TimingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimingId"));

                    b.Property<int>("HallId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("available_seats")
                        .HasColumnType("int");

                    b.Property<DateTime>("show_datetime")
                        .HasColumnType("datetime2");

                    b.HasKey("TimingId");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("ShowTiming");
                });

            modelBuilder.Entity("Webapi1.Models.ShowTiming", b =>
                {
                    b.HasOne("Webapi1.Models.MovieHall", "MovieHall")
                        .WithMany("Timing")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Webapi1.Models.Movies", "Movies")
                        .WithMany("Timing")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieHall");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Webapi1.Models.MovieHall", b =>
                {
                    b.Navigation("Timing");
                });

            modelBuilder.Entity("Webapi1.Models.Movies", b =>
                {
                    b.Navigation("Timing");
                });
#pragma warning restore 612, 618
        }
    }
}
