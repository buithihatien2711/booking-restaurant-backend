﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230625171116_UpdateTableRestaurant")]
    partial class UpdateTableRestaurant
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("backend.Data.Entities.BusinessHour", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("CloseTime")
                        .HasColumnType("time");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("OpenTime")
                        .HasColumnType("time");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("BusinessHours");
                });

            modelBuilder.Entity("backend.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("backend.Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("backend.Data.Entities.ExtraService", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExtraServices");
                });

            modelBuilder.Entity("backend.Data.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId")
                        .IsUnique()
                        .HasFilter("[RestaurantId] IS NOT NULL");

                    b.HasIndex("WardId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("backend.Data.Entities.MenuImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuImages");
                });

            modelBuilder.Entity("backend.Data.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumAdults")
                        .HasColumnType("int");

                    b.Property<int>("NumChildren")
                        .HasColumnType("int");

                    b.Property<string>("PhoneCustomer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservationStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("backend.Data.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceRange")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantStatus")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDishes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantCuisine", b =>
                {
                    b.Property<int>("TypeOfCuisineId")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TypeOfCuisineId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantCuisines");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantExtraService", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExtraServiceId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId", "ExtraServiceId");

                    b.HasIndex("ExtraServiceId");

                    b.ToTable("RestaurantExtraServices");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantImages");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantService", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TypeOfServiceId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId", "TypeOfServiceId");

                    b.HasIndex("TypeOfServiceId");

                    b.ToTable("RestaurantServices");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantSuitability", b =>
                {
                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SuitabilityId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantId", "SuitabilityId");

                    b.HasIndex("SuitabilityId");

                    b.ToTable("RestaurantSuitabilities");
                });

            modelBuilder.Entity("backend.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("backend.Data.Entities.Suitability", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suitabilities");
                });

            modelBuilder.Entity("backend.Data.Entities.TypeOfCuisine", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfCuisines");
                });

            modelBuilder.Entity("backend.Data.Entities.TypeOfService", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfServices");
                });

            modelBuilder.Entity("backend.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend.Data.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictID");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("backend.Data.Entities.BusinessHour", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("BusinessHours")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("backend.Data.Entities.District", b =>
                {
                    b.HasOne("backend.Data.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("backend.Data.Entities.Location", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithOne("Location")
                        .HasForeignKey("backend.Data.Entities.Location", "RestaurantId");

                    b.HasOne("backend.Data.Entities.Ward", "Ward")
                        .WithMany("Locations")
                        .HasForeignKey("WardId");

                    b.Navigation("Restaurant");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("backend.Data.Entities.MenuImage", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuImages")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("backend.Data.Entities.Reservation", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Data.Entities.Restaurant", b =>
                {
                    b.HasOne("backend.Data.Entities.User", "User")
                        .WithOne("Restaurant")
                        .HasForeignKey("backend.Data.Entities.Restaurant", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantCuisine", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantCuisines")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Entities.TypeOfCuisine", "TypeOfCuisine")
                        .WithMany("RestaurantCuisines")
                        .HasForeignKey("TypeOfCuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("TypeOfCuisine");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantExtraService", b =>
                {
                    b.HasOne("backend.Data.Entities.ExtraService", "ExtraService")
                        .WithMany("RestaurantExtraServices")
                        .HasForeignKey("ExtraServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantExtraServices")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExtraService");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantImage", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantImages")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantService", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantServices")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Entities.TypeOfService", "TypeOfService")
                        .WithMany("RestaurantServices")
                        .HasForeignKey("TypeOfServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("TypeOfService");
                });

            modelBuilder.Entity("backend.Data.Entities.RestaurantSuitability", b =>
                {
                    b.HasOne("backend.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("RestaurantSuitabilities")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Data.Entities.Suitability", "Suitability")
                        .WithMany("RestaurantSuitabilities")
                        .HasForeignKey("SuitabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Suitability");
                });

            modelBuilder.Entity("backend.Data.Entities.User", b =>
                {
                    b.HasOne("backend.Data.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("backend.Data.Entities.Ward", b =>
                {
                    b.HasOne("backend.Data.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("backend.Data.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("backend.Data.Entities.ExtraService", b =>
                {
                    b.Navigation("RestaurantExtraServices");
                });

            modelBuilder.Entity("backend.Data.Entities.Restaurant", b =>
                {
                    b.Navigation("BusinessHours");

                    b.Navigation("Location");

                    b.Navigation("MenuImages");

                    b.Navigation("Reservations");

                    b.Navigation("RestaurantCuisines");

                    b.Navigation("RestaurantExtraServices");

                    b.Navigation("RestaurantImages");

                    b.Navigation("RestaurantServices");

                    b.Navigation("RestaurantSuitabilities");
                });

            modelBuilder.Entity("backend.Data.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("backend.Data.Entities.Suitability", b =>
                {
                    b.Navigation("RestaurantSuitabilities");
                });

            modelBuilder.Entity("backend.Data.Entities.TypeOfCuisine", b =>
                {
                    b.Navigation("RestaurantCuisines");
                });

            modelBuilder.Entity("backend.Data.Entities.TypeOfService", b =>
                {
                    b.Navigation("RestaurantServices");
                });

            modelBuilder.Entity("backend.Data.Entities.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("backend.Data.Entities.Ward", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
