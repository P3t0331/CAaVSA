﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.Infrastructure.Persistance;

#nullable disable

namespace StockManagement.Infrastructure.Migrations
{
    [DbContext(typeof(StockManagementDbContext))]
    partial class StockManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("StockManagement.Domain.Product.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StockManagement.Domain.Stock.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockManagement.Domain.Product.Product", b =>
                {
                    b.OwnsOne("StockManagement.Domain.Product.ValueObjects.ProductDescription", "Description", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("StockManagement.Domain.Product.ValueObjects.ProductName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("StockManagement.Domain.Product.ValueObjects.ProductPrice", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("StockManagement.Domain.Product.ValueObjects.ProductSku", "Sku", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Description")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Sku")
                        .IsRequired();
                });

            modelBuilder.Entity("StockManagement.Domain.Stock.Stock", b =>
                {
                    b.OwnsOne("StockManagement.Domain.Product.ValueObjects.ProductId", "Product", b1 =>
                        {
                            b1.Property<Guid>("StockId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("StockId");

                            b1.ToTable("Stocks");

                            b1.WithOwner()
                                .HasForeignKey("StockId");
                        });

                    b.OwnsOne("StockManagement.Domain.Stock.ValueObjects.StockQuantity", "StockQuantity", b1 =>
                        {
                            b1.Property<Guid>("StockId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("StockId");

                            b1.ToTable("Stocks");

                            b1.WithOwner()
                                .HasForeignKey("StockId");
                        });

                    b.Navigation("Product")
                        .IsRequired();

                    b.Navigation("StockQuantity")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
