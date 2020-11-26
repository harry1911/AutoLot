﻿// <auto-generated />
using System;
using AutoLot.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoLot.Dal.EfStructures.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201110224847_UniqueIndex")]
    partial class UniqueIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AutoLot.Dal.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Inventory", "dbo");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.CreditRisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CreditRisks");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId", "CarId")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Car", b =>
                {
                    b.HasOne("AutoLot.Dal.Entities.Make", "MakeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MakeNavigation");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.CreditRisk", b =>
                {
                    b.HasOne("AutoLot.Dal.Entities.Customer", "CustomerNavigation")
                        .WithMany("CreditRisks")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CreditRisks_Customers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AutoLot.Dal.Entities.Owned.Person", "PersonalInformation", b1 =>
                        {
                            b1.Property<int>("CreditRiskId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("CreditRiskId");

                            b1.ToTable("CreditRisks");

                            b1.WithOwner()
                                .HasForeignKey("CreditRiskId");
                        });

                    b.Navigation("CustomerNavigation");

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Customer", b =>
                {
                    b.OwnsOne("AutoLot.Dal.Entities.Owned.Person", "PersonalInformation", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Order", b =>
                {
                    b.HasOne("AutoLot.Dal.Entities.Car", "CarNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK_Orders_Inventory")
                        .IsRequired();

                    b.HasOne("AutoLot.Dal.Entities.Customer", "CustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Orders_Customers")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarNavigation");

                    b.Navigation("CustomerNavigation");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Car", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Customer", b =>
                {
                    b.Navigation("CreditRisks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoLot.Dal.Entities.Make", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
