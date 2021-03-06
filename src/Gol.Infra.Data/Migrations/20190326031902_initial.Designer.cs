﻿// <auto-generated />
using System;
using Gol.Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gol.Infra.Data.Migrations
{
    [DbContext(typeof(GolAirlinesContext))]
    [Migration("20190326031902_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gol.Domain.Entities.Airplane", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnName("Model")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("PassengersQuantity")
                        .HasColumnName("QtdPassagers");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("Airplane");
                });
#pragma warning restore 612, 618
        }
    }
}
