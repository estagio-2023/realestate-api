﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealEstateLibrary;

#nullable disable

namespace RealEstateLibrary.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240624120644_RealEstateHasAmenityConnection")]
    partial class RealEstateHasAmenityConnection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RealEstateLibrary.Entities.AgentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.HasKey("Id");

                    b.ToTable("agents", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.AmenityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("amenities", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("BuildDate")
                        .HasColumnType("integer");

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("EnergyClass")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("numeric(8,2)");

                    b.Property<int>("RealEstateTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("SquareMeter")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TypologyId")
                        .HasColumnType("integer");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RealEstateTypeId");

                    b.HasIndex("TypologyId");

                    b.ToTable("real_estates", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateHasAmenityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AmenitiesId")
                        .HasColumnType("integer");

                    b.Property<int>("AmenityId")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AmenityId");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateHasAmenities");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("realestate_types", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.TypologyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("typologies", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.VisitRequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("integer");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("RealEstateId");

                    b.ToTable("visits_requests", (string)null);
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateEntity", b =>
                {
                    b.HasOne("RealEstateLibrary.Entities.CityEntity", "City")
                        .WithMany("RealEstates")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateLibrary.Entities.CustomerEntity", "Customer")
                        .WithMany("RealEstates")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateLibrary.Entities.RealEstateTypeEntity", "RealEstateType")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateLibrary.Entities.TypologyEntity", "Typology")
                        .WithMany("RealEstates")
                        .HasForeignKey("TypologyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Customer");

                    b.Navigation("RealEstateType");

                    b.Navigation("Typology");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateHasAmenityEntity", b =>
                {
                    b.HasOne("RealEstateLibrary.Entities.AmenityEntity", "Amenity")
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateLibrary.Entities.RealEstateEntity", "RealEstate")
                        .WithMany("RealEstateHasAmenities")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.VisitRequestEntity", b =>
                {
                    b.HasOne("RealEstateLibrary.Entities.AgentEntity", "Agent")
                        .WithMany("VisitRequests")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateLibrary.Entities.RealEstateEntity", "RealEstates")
                        .WithMany("VisitRequests")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.AgentEntity", b =>
                {
                    b.Navigation("VisitRequests");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.CityEntity", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.CustomerEntity", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateEntity", b =>
                {
                    b.Navigation("RealEstateHasAmenities");

                    b.Navigation("VisitRequests");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.RealEstateTypeEntity", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateLibrary.Entities.TypologyEntity", b =>
                {
                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
