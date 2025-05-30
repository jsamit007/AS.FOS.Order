﻿// <auto-generated />
using System;
using AS.FOS.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AS.FOS.Order.Persistence.Migrations
{
    [DbContext(typeof(OrderDBContext))]
    [Migration("20250426115245_InitialCommit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AS.FOS.Order.Domain.Aggregates.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Cutomers");
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderEntityId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderEntityId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Entities.Resturant", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.HasKey("RestaurantId");

                    b.ToTable("Resturants");
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Aggregates.OrderEntity", b =>
                {
                    b.HasOne("AS.FOS.Order.Domain.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AS.FOS.Order.Domain.Entities.Resturant", null)
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("AS.FOS.Order.Domain.ValueObjects.DeliveryAddress", "DeliveryAddress", b1 =>
                        {
                            b1.Property<Guid>("OrderEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("OrderEntityId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderEntityId");
                        });

                    b.Navigation("DeliveryAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("AS.FOS.Order.Domain.Aggregates.OrderEntity", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AS.FOS.Order.Domain.Aggregates.OrderEntity", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
