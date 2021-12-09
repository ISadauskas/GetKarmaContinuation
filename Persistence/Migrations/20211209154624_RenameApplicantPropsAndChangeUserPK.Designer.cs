﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ItemDbContext))]
    [Migration("20211209154624_RenameApplicantPropsAndChangeUserPK")]
    partial class RenameApplicantPropsAndChangeUserPK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Applicant", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Redeemer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Uploaded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Uploader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAuthId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("WinnerChosenRandomly")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("UserAuthId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Domain.Entities.ListingImage", b =>
                {
                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ListingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ImageUrl");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Domain.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("PriceRating")
                        .HasColumnType("smallint");

                    b.Property<short>("QualityRating")
                        .HasColumnType("smallint");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<string>("AuthId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Applicant", b =>
                {
                    b.HasOne("Domain.Entities.Item", "Item")
                        .WithMany("Applicants")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.HasOne("Domain.Entities.User", null)
                        .WithMany("Listings")
                        .HasForeignKey("UserAuthId");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Navigation("Applicants");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Listings");
                });
#pragma warning restore 612, 618
        }
    }
}
