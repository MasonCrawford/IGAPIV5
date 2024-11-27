﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(TradingAppContext))]
    [Migration("20220107143144_AddedLoggingTable")]
    partial class AddedLoggingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.DepositBandEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Margin")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("Max")
                        .HasColumnType("int");

                    b.Property<int?>("Min")
                        .HasColumnType("int");

                    b.Property<Guid?>("TradingTargetEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TradingTargetEntityId");

                    b.ToTable("DepositBand");
                });

            modelBuilder.Entity("DataAccess.Entities.LogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Msg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationLogs");
                });

            modelBuilder.Entity("DataAccess.Entities.OrdersEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ContractSize")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Deposit")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Profit")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("RiskAmount")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("TargetAmount")
                        .HasColumnType("decimal(18,6)");

                    b.Property<Guid>("TradingTargetEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TransactionReference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TradingTargetEntityId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataAccess.Entities.PriceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Ask")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("Bid")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("LastTraded")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("DataAccess.Entities.PricesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClosePriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HighPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LowPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("MovingAverage")
                        .HasColumnType("decimal(18,6)");

                    b.Property<Guid?>("OpenPriceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TradingChartEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClosePriceId");

                    b.HasIndex("HighPriceId");

                    b.HasIndex("LowPriceId");

                    b.HasIndex("OpenPriceId");

                    b.HasIndex("TradingChartEntityId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("DataAccess.Entities.ProgramEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ReSeed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Program");
                });

            modelBuilder.Entity("DataAccess.Entities.TradingChartEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChartCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TradingChart");
                });

            modelBuilder.Entity("DataAccess.Entities.TradingTargetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChartCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Epic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expiry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("InitialDeposit")
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime?>("LastModifiedOnUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<int?>("MovingAverageLength")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Profit")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal?>("RiskPercent")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("ScalingFactor")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal?>("TargetPercent")
                        .HasColumnType("decimal(18,6)");

                    b.Property<int?>("TradingLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TradingTargets");
                });

            modelBuilder.Entity("DataAccess.Entities.DepositBandEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.TradingTargetEntity", null)
                        .WithMany("MarginDepositBands")
                        .HasForeignKey("TradingTargetEntityId");
                });

            modelBuilder.Entity("DataAccess.Entities.OrdersEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.TradingTargetEntity", "TradingTargetEntity")
                        .WithMany("Orders")
                        .HasForeignKey("TradingTargetEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradingTargetEntity");
                });

            modelBuilder.Entity("DataAccess.Entities.PricesEntity", b =>
                {
                    b.HasOne("DataAccess.Entities.PriceEntity", "ClosePrice")
                        .WithMany()
                        .HasForeignKey("ClosePriceId");

                    b.HasOne("DataAccess.Entities.PriceEntity", "HighPrice")
                        .WithMany()
                        .HasForeignKey("HighPriceId");

                    b.HasOne("DataAccess.Entities.PriceEntity", "LowPrice")
                        .WithMany()
                        .HasForeignKey("LowPriceId");

                    b.HasOne("DataAccess.Entities.PriceEntity", "OpenPrice")
                        .WithMany()
                        .HasForeignKey("OpenPriceId");

                    b.HasOne("DataAccess.Entities.TradingChartEntity", null)
                        .WithMany("Prices")
                        .HasForeignKey("TradingChartEntityId");

                    b.Navigation("ClosePrice");

                    b.Navigation("HighPrice");

                    b.Navigation("LowPrice");

                    b.Navigation("OpenPrice");
                });

            modelBuilder.Entity("DataAccess.Entities.TradingChartEntity", b =>
                {
                    b.Navigation("Prices");
                });

            modelBuilder.Entity("DataAccess.Entities.TradingTargetEntity", b =>
                {
                    b.Navigation("MarginDepositBands");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
