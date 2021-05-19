﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetFinal_MAUREL_CHEVILLARD.Data;

namespace ProjetFinal_MAUREL_CHEVILLARD.Migrations
{
    [DbContext(typeof(ProjetFinal_MAUREL_CHEVILLARDContext))]
    partial class ProjetFinal_MAUREL_CHEVILLARDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetFinal_MAUREL_CHEVILLARD.Models.Freelance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrutSalary")
                        .HasColumnType("int");

                    b.Property<string>("Civility")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ConfidentialityPoliticAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("DayByMonthDuration")
                        .HasColumnType("int");

                    b.Property<int>("DayPrice")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HourPrice")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LessOneMonthDuration")
                        .HasColumnType("bit");

                    b.Property<bool>("MarketingOfferAccepted")
                        .HasColumnType("bit");

                    b.Property<int>("MonthDuration")
                        .HasColumnType("int");

                    b.Property<int>("MonthPrice")
                        .HasColumnType("int");

                    b.Property<int>("NetSalary")
                        .HasColumnType("int");

                    b.Property<bool>("NotKnowPrice")
                        .HasColumnType("bit");

                    b.Property<string>("ResidenceCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SimulationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurnOver")
                        .HasColumnType("int");

                    b.Property<string>("WorkCountry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Freelance");
                });
#pragma warning restore 612, 618
        }
    }
}