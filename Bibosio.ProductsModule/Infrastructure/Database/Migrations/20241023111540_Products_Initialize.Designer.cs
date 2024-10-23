﻿// <auto-generated />
using System;
using Bibosio.ProductsModule.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bibosio.ProductsModule.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20241023111540_Products_Initialize")]
    partial class Products_Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("product")
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Categories", "product");
                });

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.Option", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Options", "product");
                });

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.OptionValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("OptionsValues", "product");
                });

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Products", "product");
                });

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.ProductOptionValue", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OptionValueId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "OptionId", "OptionValueId");

                    b.ToTable("ProductOptionValues", "product");
                });

            modelBuilder.Entity("Bibosio.ProductsModule.Domain.Product", b =>
                {
                    b.OwnsOne("Bibosio.ProductsModule.Domain.ValueObjects.Sku", "Sku", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products", "product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Sku")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
