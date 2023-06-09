﻿// <auto-generated />
using System;
using InstantLicenses.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstantLicenses.DataLayer.Migrations
{
    [DbContext(typeof(License_Context))]
    [Migration("20230328110548_InitialCreate_v3")]
    partial class InitialCreate_v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("InstantLicenses.DataLayer.DbModels.License", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientRent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("RentedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
