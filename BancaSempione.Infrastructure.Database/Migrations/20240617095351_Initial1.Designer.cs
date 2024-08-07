﻿// <auto-generated />
using System;
using BancaSempione.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BancaSempione.Infrastructure.Database.Migrations
{
    [DbContext(typeof(DivisaContext))]
    [Migration("20240617095351_Initial1")]
    partial class Initial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Sempione_Currency")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BancaSempione.Domain.Divise.GruppoDivisa", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("GruppoDivisa", "Sempione_Currency");
                });

            modelBuilder.Entity("BancaSempione.Domain.Divise.SerilogRow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExceptionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs", "Sempione_Currency");
                });

            modelBuilder.Entity("BancaSempione.Domain.Divise.TipoDivisa", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoDivisa", "Sempione_Currency");
                });

            modelBuilder.Entity("BancaSempione.Infrastructure.Database.Model.CorsoDivisaRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AskRate")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("BaseCurrencyCode")
                        .HasColumnType("int");

                    b.Property<decimal>("BidRate")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("CounterCurrencyCode")
                        .HasColumnType("int");

                    b.Property<decimal>("PreviousExchangeRate")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("TipoCorsoDivisa")
                        .HasColumnType("int");

                    b.Property<long>("ValidFromUtc")
                        .HasColumnType("bigint");

                    b.Property<long>("ValidToUtc")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyCode", "CounterCurrencyCode", "TipoCorsoDivisa");

                    b.HasIndex("BaseCurrencyCode", "CounterCurrencyCode", "TipoCorsoDivisa", "ValidFromUtc")
                        .IsUnique();

                    b.ToTable("CorsoDivisa", "Sempione_Currency");
                });

            modelBuilder.Entity("BancaSempione.Infrastructure.Database.Model.DivisaRecord", b =>
                {
                    b.Property<int>("DivisaId")
                        .HasColumnType("int");

                    b.Property<string>("AlphabeticCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("DecimalDigits")
                        .HasColumnType("int");

                    b.Property<int>("GruppoDivisaId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDivisaIn")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NumericCode")
                        .HasColumnType("int");

                    b.Property<int>("Rounding")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Taglio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoDivisaId")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("DivisaId");

                    b.HasIndex("AlphabeticCode")
                        .IsUnique();

                    b.HasIndex("NumericCode")
                        .IsUnique();

                    b.ToTable("Divisa", "Sempione_Currency");
                });
#pragma warning restore 612, 618
        }
    }
}
