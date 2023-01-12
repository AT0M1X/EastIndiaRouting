﻿// <auto-generated />
using System;
using EIT.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EIT.Migrations
{
    [DbContext(typeof(RoutingContext))]
    partial class RoutingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EIT.Model.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("EIT.Model.PackageType", b =>
                {
                    b.Property<int>("PackageTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageTypeID"));

                    b.Property<int>("Fee")
                        .HasColumnType("int");

                    b.Property<string>("PackageTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Supported")
                        .HasColumnType("bit");

                    b.HasKey("PackageTypeID");

                    b.ToTable("PackageTypes");
                });

            modelBuilder.Entity("EIT.Model.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EIT.Model.Route", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteID"));

                    b.Property<int?>("DestinationCityCityID")
                        .HasColumnType("int");

                    b.Property<int?>("OriginCityCityID")
                        .HasColumnType("int");

                    b.Property<int>("Segments")
                        .HasColumnType("int");

                    b.HasKey("RouteID");

                    b.HasIndex("DestinationCityCityID");

                    b.HasIndex("OriginCityCityID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("EIT.Model.ServiceAccount", b =>
                {
                    b.Property<int>("ServiceAccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceAccountID"));

                    b.Property<Guid>("CollaborationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceAccountID");

                    b.ToTable("ServiceAccounts");
                });

            modelBuilder.Entity("EIT.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EIT.Model.WeightClass", b =>
                {
                    b.Property<int>("WeightClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeightClassID"));

                    b.Property<int>("MaximumWeight")
                        .HasColumnType("int");

                    b.Property<int>("MinimumWeight")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("WeightClassID");

                    b.ToTable("WeightClasses");
                });

            modelBuilder.Entity("EIT.Model.Route", b =>
                {
                    b.HasOne("EIT.Model.City", "DestinationCity")
                        .WithMany()
                        .HasForeignKey("DestinationCityCityID");

                    b.HasOne("EIT.Model.City", "OriginCity")
                        .WithMany()
                        .HasForeignKey("OriginCityCityID");

                    b.Navigation("DestinationCity");

                    b.Navigation("OriginCity");
                });

            modelBuilder.Entity("EIT.Model.User", b =>
                {
                    b.HasOne("EIT.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
