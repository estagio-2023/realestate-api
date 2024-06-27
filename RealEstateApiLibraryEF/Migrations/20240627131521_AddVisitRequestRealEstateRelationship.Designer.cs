﻿// <auto-generated />
using System;
using RealEstateApiLibraryEF.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstateApiLibraryEF.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    [Migration("20240627131521_AddVisitRequestRealEstateRelationship")]
    partial class AddVisitRequestRealEstateRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_agents");

                    b.ToTable("agents", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Amenities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_amenities");

                    b.ToTable("amenities", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_cities");

                    b.ToTable("cities", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("address");

                    b.Property<int>("BuildDate")
                        .HasColumnType("integer")
                        .HasColumnName("build_date");

                    b.Property<int>("CityId")
                        .HasColumnType("integer")
                        .HasColumnName("city_id");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("description");

                    b.Property<string>("EnergyClass")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("energy_class");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("numeric(8,2)")
                        .HasColumnName("price");

                    b.Property<int>("RealEstateTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("real_estate_type_id");

                    b.Property<int>("SquareMeter")
                        .HasColumnType("integer")
                        .HasColumnName("square_meter");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.Property<int>("TypologyId")
                        .HasColumnType("integer")
                        .HasColumnName("typology_id");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_real_estates");

                    b.HasIndex("CityId")
                        .HasDatabaseName("ix_real_estates_city_id");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_real_estates_customer_id");

                    b.HasIndex("RealEstateTypeId")
                        .HasDatabaseName("ix_real_estates_real_estate_type_id");

                    b.HasIndex("TypologyId")
                        .HasDatabaseName("ix_real_estates_typology_id");

                    b.ToTable("real_estates", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.RealEstateType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_realestate_types");

                    b.ToTable("realestate_types", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Typology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_typologies");

                    b.ToTable("typologies", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.VisitRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgentId")
                        .HasColumnType("integer")
                        .HasColumnName("agent_id");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("confirmed");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("interval")
                        .HasColumnName("end_time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("name");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer")
                        .HasColumnName("real_estate_id");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval")
                        .HasColumnName("start_time");

                    b.HasKey("Id")
                        .HasName("pk_visits_requests");

                    b.HasIndex("AgentId")
                        .HasDatabaseName("ix_visits_requests_agent_id");

                    b.HasIndex("RealEstateId")
                        .HasDatabaseName("ix_visits_requests_real_estate_id");

                    b.ToTable("visits_requests", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.RealEstate", b =>
                {
                    b.HasOne("RealEstateApiLibraryEF.Entity.City", "City")
                        .WithMany("RealEstates")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_real_estates_cities_city_id");

                    b.HasOne("RealEstateApiLibraryEF.Entity.Customer", "Customer")
                        .WithMany("RealEstates")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_real_estates_customers_customer_id");

                    b.HasOne("RealEstateApiLibraryEF.Entity.RealEstateType", "RealEstateType")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_real_estates_real_estate_types_real_estate_type_id");

                    b.HasOne("RealEstateApiLibraryEF.Entity.Typology", "Typology")
                        .WithMany("RealEstates")
                        .HasForeignKey("TypologyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_real_estates_typologies_typology_id");

                    b.Navigation("City");

                    b.Navigation("Customer");

                    b.Navigation("RealEstateType");

                    b.Navigation("Typology");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.VisitRequest", b =>
                {
                    b.HasOne("RealEstateApiLibraryEF.Entity.Agent", "Agent")
                        .WithMany("VisitRequests")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_visits_requests_agents_agent_id");

                    b.HasOne("RealEstateApiLibraryEF.Entity.RealEstate", "RealEstate")
                        .WithMany("VisitRequests")
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_visits_requests_real_estates_real_estate_id");

                    b.Navigation("Agent");

                    b.Navigation("RealEstate");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Agent", b =>
                {
                    b.Navigation("VisitRequests");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.City", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Customer", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.RealEstate", b =>
                {
                    b.Navigation("VisitRequests");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.RealEstateType", b =>
                {
                    b.Navigation("RealEstates");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Typology", b =>
                {
                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
