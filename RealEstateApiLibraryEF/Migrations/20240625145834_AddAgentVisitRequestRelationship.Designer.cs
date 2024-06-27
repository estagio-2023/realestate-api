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
    [Migration("20240625145834_AddAgentVisitRequestRelationship")]
    partial class AddAgentVisitRequestRelationship
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

                    b.ToTable("visits_requests", (string)null);
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.VisitRequest", b =>
                {
                    b.HasOne("RealEstateApiLibraryEF.Entity.Agent", "Agent")
                        .WithMany("VisitRequests")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_visits_requests_agents_agent_id");

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("RealEstateApiLibraryEF.Entity.Agent", b =>
                {
                    b.Navigation("VisitRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
