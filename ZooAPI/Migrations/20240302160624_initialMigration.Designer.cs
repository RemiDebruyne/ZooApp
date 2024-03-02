﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ZooAPI.Data;

#nullable disable

namespace ZooAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240302160624_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ZooCore.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<int>("Family")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Size")
                        .HasPrecision(37, 2)
                        .HasColumnType("numeric(37,2)");

                    b.Property<int>("Species")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Weight")
                        .HasPrecision(37, 2)
                        .HasColumnType("numeric(37,2)");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 12,
                            Color = "Dark grey",
                            Family = 2,
                            Name = "Balou",
                            Species = 2
                        },
                        new
                        {
                            Id = 2,
                            Age = 10,
                            Color = "Orange",
                            Family = 0,
                            Name = "Tigrou",
                            Species = 0
                        },
                        new
                        {
                            Id = 3,
                            Age = 37,
                            Color = "Brown",
                            Family = 1,
                            Name = "USA",
                            Species = 4
                        });
                });
#pragma warning restore 612, 618
        }
    }
}