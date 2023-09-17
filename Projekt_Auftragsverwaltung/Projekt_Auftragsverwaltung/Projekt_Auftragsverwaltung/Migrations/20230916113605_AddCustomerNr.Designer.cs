﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekt_Auftragsverwaltung;

#nullable disable

namespace ProjektAuftragsverwaltung.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230916113605_AddCustomerNr")]
    partial class AddCustomerNr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("AddressId");

                    b.HasIndex("ZipCode");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            HouseNumber = "42",
                            Street = "Oberer Graben",
                            ZipCode = 9000
                        },
                        new
                        {
                            AddressId = 2,
                            HouseNumber = "6",
                            Street = "Vorderbrenden",
                            ZipCode = 9426
                        },
                        new
                        {
                            AddressId = 3,
                            HouseNumber = "36",
                            Street = "Teufener Strasse",
                            ZipCode = 9001
                        },
                        new
                        {
                            AddressId = 4,
                            HouseNumber = "4",
                            Street = "Seeblickstrasse",
                            ZipCode = 9424
                        },
                        new
                        {
                            AddressId = 5,
                            HouseNumber = "12",
                            Street = "Bahnhofsstrasse",
                            ZipCode = 8000
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.AddressLocation", b =>
                {
                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("ZipCode");

                    b.ToTable("AddressLocations");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("AddressLocationsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            ZipCode = 9000,
                            Location = "St. Gallen"
                        },
                        new
                        {
                            ZipCode = 9426,
                            Location = "Lutzenberg"
                        },
                        new
                        {
                            ZipCode = 9424,
                            Location = "Rheineck"
                        },
                        new
                        {
                            ZipCode = 9001,
                            Location = "St. Gallen"
                        },
                        new
                        {
                            ZipCode = 8000,
                            Location = "Zürich"
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"));

                    b.Property<int>("ArticleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticleId");

                    b.HasIndex("ArticleGroupId");

                    b.ToTable("Articles");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("ArticlesHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            ArticleGroupId = 1,
                            ArticleName = "Handschuhe",
                            Price = 10.0m
                        },
                        new
                        {
                            ArticleId = 2,
                            ArticleGroupId = 2,
                            ArticleName = "Schwamm",
                            Price = 20.0m
                        },
                        new
                        {
                            ArticleId = 3,
                            ArticleGroupId = 2,
                            ArticleName = "Besen",
                            Price = 30.0m
                        },
                        new
                        {
                            ArticleId = 4,
                            ArticleGroupId = 3,
                            ArticleName = "Hüpfburg",
                            Price = 40.0m
                        },
                        new
                        {
                            ArticleId = 5,
                            ArticleGroupId = 1,
                            ArticleName = "Kettensäge",
                            Price = 50.0m
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.ArticleGroup", b =>
                {
                    b.Property<int>("ArticleGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleGroupId"));

                    b.Property<int?>("ArticleGroupId1")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("ArticleGroupId");

                    b.HasIndex("ArticleGroupId1");

                    b.ToTable("ArticleGroups");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("ArticleGroupsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            ArticleGroupId = 1,
                            Level = 0,
                            Name = "Werkzeuge"
                        },
                        new
                        {
                            ArticleGroupId = 2,
                            Level = 0,
                            Name = "Hygiene"
                        },
                        new
                        {
                            ArticleGroupId = 3,
                            Level = 0,
                            Name = "Kinder"
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.ArticlePosition", b =>
                {
                    b.Property<int>("ArticlePositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticlePositionId"));

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("OrderPositionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("ArticlePositionId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("OrderPositionId");

                    b.ToTable("ArticlePositions");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("ArticlePositionsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            ArticlePositionId = 1,
                            ArticleId = 1,
                            OrderPositionId = 1
                        },
                        new
                        {
                            ArticlePositionId = 2,
                            ArticleId = 2,
                            OrderPositionId = 2
                        },
                        new
                        {
                            ArticlePositionId = 3,
                            ArticleId = 3,
                            OrderPositionId = 3
                        },
                        new
                        {
                            ArticlePositionId = 4,
                            ArticleId = 4,
                            OrderPositionId = 4
                        },
                        new
                        {
                            ArticlePositionId = 5,
                            ArticleId = 5,
                            OrderPositionId = 5
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerNr")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("CustomersHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            AddressId = 1,
                            CustomerNr = "",
                            EMail = "marco-mayer@gmx.com",
                            Name = "Marco Mayer",
                            Password = "pass1",
                            PhoneNumber = "0123456789",
                            Website = "servicesolution.com"
                        },
                        new
                        {
                            CustomerId = 2,
                            AddressId = 2,
                            CustomerNr = "",
                            EMail = "ps@gmail.com",
                            Name = "Peter Steiner",
                            Password = "pass2",
                            PhoneNumber = "9876543210",
                            Website = "funreisen.ch"
                        },
                        new
                        {
                            CustomerId = 3,
                            AddressId = 3,
                            CustomerNr = "",
                            EMail = "jh@gmx.com",
                            Name = "Julia Heeb",
                            Password = "pass3",
                            PhoneNumber = "1234567890",
                            Website = "geschenkideen.ch"
                        },
                        new
                        {
                            CustomerId = 4,
                            AddressId = 4,
                            CustomerNr = "",
                            EMail = "lärihugi@hotmail.com",
                            Name = "Larissa Hugentobler",
                            Password = "pass4",
                            PhoneNumber = "0987654321",
                            Website = "gmx.ch"
                        },
                        new
                        {
                            CustomerId = 5,
                            AddressId = 5,
                            CustomerNr = "",
                            EMail = "PCMeier@sunrise.com",
                            Name = "Pascal Meier",
                            Password = "pass5",
                            PhoneNumber = "1023456789",
                            Website = "meierbau.ch"
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("OrdersHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerId = 1,
                            Date = new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerId = 2,
                            Date = new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 3,
                            CustomerId = 3,
                            Date = new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 4,
                            CustomerId = 4,
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            OrderId = 5,
                            CustomerId = 5,
                            Date = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.OrderPosition", b =>
                {
                    b.Property<int>("OrderPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderPositionId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.HasKey("OrderPositionId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderPositions");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("OrderPositionsHistory");
                                ttb
                                    .HasPeriodStart("PeriodStart")
                                    .HasColumnName("PeriodStart");
                                ttb
                                    .HasPeriodEnd("PeriodEnd")
                                    .HasColumnName("PeriodEnd");
                            }));

                    b.HasData(
                        new
                        {
                            OrderPositionId = 1,
                            OrderId = 1,
                            amount = 5
                        },
                        new
                        {
                            OrderPositionId = 2,
                            OrderId = 2,
                            amount = 10
                        },
                        new
                        {
                            OrderPositionId = 3,
                            OrderId = 3,
                            amount = 3
                        },
                        new
                        {
                            OrderPositionId = 4,
                            OrderId = 4,
                            amount = 8
                        },
                        new
                        {
                            OrderPositionId = 5,
                            OrderId = 5,
                            amount = 15
                        });
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Address", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.AddressLocation", "AddressLocation")
                        .WithMany("Addresses")
                        .HasForeignKey("ZipCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressLocation");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Article", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.ArticleGroup", "ArticleGroup")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleGroup");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.ArticleGroup", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.ArticleGroup", null)
                        .WithMany("Children")
                        .HasForeignKey("ArticleGroupId1");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.ArticlePosition", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.Article", "Article")
                        .WithMany("OrderPositions")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projekt_Auftragsverwaltung.Tables.OrderPosition", "OrderPosition")
                        .WithMany("Articles")
                        .HasForeignKey("OrderPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("OrderPosition");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Customer", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.Address", "Address")
                        .WithOne("Customer")
                        .HasForeignKey("Projekt_Auftragsverwaltung.Tables.Customer", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Order", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.OrderPosition", b =>
                {
                    b.HasOne("Projekt_Auftragsverwaltung.Tables.Order", "Order")
                        .WithMany("OrderPositions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Address", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.AddressLocation", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Article", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.ArticleGroup", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Children");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.Order", b =>
                {
                    b.Navigation("OrderPositions");
                });

            modelBuilder.Entity("Projekt_Auftragsverwaltung.Tables.OrderPosition", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}