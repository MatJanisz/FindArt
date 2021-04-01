﻿// <auto-generated />
using System;
using FindArt.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FindArt.DataAccess.Migrations
{
    [DbContext(typeof(FindArtDbContext))]
    [Migration("20210401212225_AssignAdminRoleToAdminUser")]
    partial class AssignAdminRoleToAdminUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FindArt.Core.Models.Auction", b =>
                {
                    b.Property<string>("AuctionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InitialPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuctionID");

                    b.HasIndex("ProductID")
                        .IsUnique()
                        .HasFilter("[ProductID] IS NOT NULL");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("FindArt.Core.Models.Offer", b =>
                {
                    b.Property<string>("OfferID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("BeatenPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BuyerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("ProposedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OfferID");

                    b.HasIndex("AuctionID");

                    b.HasIndex("BuyerID");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("FindArt.Core.Models.Product", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuctionID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OwnerID");

                    b.HasIndex("ProductTypeID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FindArt.Core.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductTypeID");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            ProductTypeID = 0,
                            Name = "Painting"
                        },
                        new
                        {
                            ProductTypeID = 1,
                            Name = "Drawing"
                        },
                        new
                        {
                            ProductTypeID = 2,
                            Name = "Graphics"
                        },
                        new
                        {
                            ProductTypeID = 3,
                            Name = "Calligraphy"
                        },
                        new
                        {
                            ProductTypeID = 4,
                            Name = "Fotography"
                        },
                        new
                        {
                            ProductTypeID = 5,
                            Name = "Architecture"
                        },
                        new
                        {
                            ProductTypeID = 6,
                            Name = "Sculpture"
                        },
                        new
                        {
                            ProductTypeID = 7,
                            Name = "Ceramics"
                        });
                });

            modelBuilder.Entity("FindArt.Core.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "da919e90-4651-4f55-bfc8-400a41bc57b0",
                            ConcurrencyStamp = "1d437cbe-e344-4447-9d5b-da6e0022f761",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FindArt.Core.Models.Auction", b =>
                {
                    b.HasOne("FindArt.Core.Models.Product", "Product")
                        .WithOne("Auction")
                        .HasForeignKey("FindArt.Core.Models.Auction", "ProductID");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FindArt.Core.Models.Offer", b =>
                {
                    b.HasOne("FindArt.Core.Models.Auction", "Auction")
                        .WithMany("AuctionOffers")
                        .HasForeignKey("AuctionID");

                    b.HasOne("FindArt.Core.Models.User", "Buyer")
                        .WithMany("SubmittedOffers")
                        .HasForeignKey("BuyerID");

                    b.Navigation("Auction");

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("FindArt.Core.Models.Product", b =>
                {
                    b.HasOne("FindArt.Core.Models.User", "Owner")
                        .WithMany("ProductsOnAuction")
                        .HasForeignKey("OwnerID");

                    b.HasOne("FindArt.Core.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FindArt.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FindArt.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FindArt.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FindArt.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FindArt.Core.Models.Auction", b =>
                {
                    b.Navigation("AuctionOffers");
                });

            modelBuilder.Entity("FindArt.Core.Models.Product", b =>
                {
                    b.Navigation("Auction");
                });

            modelBuilder.Entity("FindArt.Core.Models.ProductType", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FindArt.Core.Models.User", b =>
                {
                    b.Navigation("ProductsOnAuction");

                    b.Navigation("SubmittedOffers");
                });
#pragma warning restore 612, 618
        }
    }
}
