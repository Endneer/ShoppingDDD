﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ShoppingContext))]
    [Migration("20190722163804_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Core.Models.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CustomerId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Core.Models.OrderAggregate.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Core.Models.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Models.CustomerAggregate.Customer", b =>
                {
                    b.OwnsOne("Core.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId");

                            b1.Property<int>("Building");

                            b1.Property<string>("City");

                            b1.Property<string>("Country");

                            b1.Property<string>("Street");

                            b1.ToTable("Customers");

                            b1.HasOne("Core.Models.CustomerAggregate.Customer")
                                .WithOne("Address")
                                .HasForeignKey("Core.Models.ValueObjects.Address", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Core.Models.ValueObjects.PhoneNubmer", "PhoneNubmer", b1 =>
                        {
                            b1.Property<Guid>("CustomerId");

                            b1.Property<long>("Number");

                            b1.ToTable("Customers");

                            b1.HasOne("Core.Models.CustomerAggregate.Customer")
                                .WithOne("PhoneNubmer")
                                .HasForeignKey("Core.Models.ValueObjects.PhoneNubmer", "CustomerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Core.Models.OrderAggregate.Order", b =>
                {
                    b.HasOne("Core.Models.CustomerAggregate.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Models.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("Core.Models.OrderAggregate.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
