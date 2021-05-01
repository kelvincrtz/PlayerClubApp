﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayerClub.API.Data;

namespace PlayerClub.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("PlayerClub.API.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("PlayerClub.API.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coach")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FoundedYear")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ground")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PlayerClub.API.Models.Player", b =>
                {
                    b.HasOne("PlayerClub.API.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });
#pragma warning restore 612, 618
        }
    }
}
