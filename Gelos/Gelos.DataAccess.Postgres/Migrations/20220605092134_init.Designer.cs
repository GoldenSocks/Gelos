﻿// <auto-generated />
using System;
using Gelos.DataAccess.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Gelos.DataAccess.Postgres.Migrations
{
    [DbContext(typeof(GelosContext))]
    [Migration("20220605092134_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Gelos.DataAccess.Postgres.Entities.EmployeeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Gelos.DataAccess.Postgres.Entities.IssueDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Gelos.DataAccess.Postgres.Entities.IssueDto", b =>
                {
                    b.HasOne("Gelos.DataAccess.Postgres.Entities.EmployeeDto", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");

                    b.HasOne("Gelos.DataAccess.Postgres.Entities.EmployeeDto", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.Navigation("Executor");

                    b.Navigation("Provider");
                });
#pragma warning restore 612, 618
        }
    }
}
