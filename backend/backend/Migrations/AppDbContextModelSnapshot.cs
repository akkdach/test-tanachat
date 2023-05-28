﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("orderId"));

                    b.Property<string>("createBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<int>("orderDate")
                        .HasColumnType("integer");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<double>("qty")
                        .HasColumnType("double precision");

                    b.Property<string>("updateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("orderId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("backend.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("productId"));

                    b.Property<string>("createBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<double>("unitPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("updateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("productId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("backend.Models.Stock", b =>
                {
                    b.Property<int>("stockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("stockId"));

                    b.Property<string>("createBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<double>("qty")
                        .HasColumnType("double precision");

                    b.Property<string>("updateBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("stockId");

                    b.ToTable("stocks");
                });
#pragma warning restore 612, 618
        }
    }
}