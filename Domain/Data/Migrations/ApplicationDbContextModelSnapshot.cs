﻿// <auto-generated />
using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("BlockId")
                        .HasColumnType("int");

                    b.Property<int?>("HouseNo")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("PollCenterId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetId")
                        .HasColumnType("int");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("PollCenterId");

                    b.HasIndex("StreetId");

                    b.HasIndex("VillageId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AddressId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HasPasswordChange")
                        .HasColumnType("int");

                    b.Property<string>("ImgPath")
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

                    b.Property<string>("SocialNetwork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Domain.Data.Entities.Help", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActivitiesYouPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CanYouManage")
                        .HasColumnType("bit");

                    b.Property<bool?>("NeedHelp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Helps");
                });

            modelBuilder.Entity("Domain.Data.Entities.Kqzregister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DataCreated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElectionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfvotes")
                        .HasColumnType("int");

                    b.Property<string>("PoliticialSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PollCenterId")
                        .HasColumnType("int");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("PollCenterId");

                    b.HasIndex("VillageId");

                    b.ToTable("Kqzregisters");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("VillageId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CenterNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipalitydId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalitydId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("VillageId");

                    b.ToTable("PollCenters");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollRelated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Demand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FamMembers")
                        .HasColumnType("int");

                    b.Property<int?>("HelpId")
                        .HasColumnType("int");

                    b.Property<string>("PoliticialSubjectLocal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliticialSubjectNational")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuccessChances")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VoterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("HelpId");

                    b.HasIndex("VoterId");

                    b.ToTable("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<string>("StreetSource")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("VillageId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Domain.Data.Entities.Village", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("Domain.Data.Entities.Voter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActualStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialNetwork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("WorkId");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdministrativeUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Works");
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.HasOne("Domain.Data.Entities.Block", "Block")
                        .WithMany("Addresses")
                        .HasForeignKey("BlockId");

                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Addresses")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Domain.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Addresses")
                        .HasForeignKey("NeighborhoodId");

                    b.HasOne("Domain.Data.Entities.PollCenter", "PollCenter")
                        .WithMany("Addresses")
                        .HasForeignKey("PollCenterId");

                    b.HasOne("Domain.Data.Entities.Street", "Street")
                        .WithMany("Addresses")
                        .HasForeignKey("StreetId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("Addresses")
                        .HasForeignKey("VillageId");

                    b.Navigation("Block");

                    b.Navigation("Municipality");

                    b.Navigation("Neighborhood");

                    b.Navigation("PollCenter");

                    b.Navigation("Street");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Data.Entities.Address", "Address")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Blocks")
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("Domain.Data.Entities.Kqzregister", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Domain.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("NeighborhoodId");

                    b.HasOne("Domain.Data.Entities.PollCenter", "PollCenter")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("PollCenterId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("VillageId");

                    b.Navigation("Municipality");

                    b.Navigation("Neighborhood");

                    b.Navigation("PollCenter");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neighborhood", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("VillageId");

                    b.Navigation("Municipality");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipalityd")
                        .WithMany("PollCenters")
                        .HasForeignKey("MunicipalitydId");

                    b.HasOne("Domain.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("PollCenters")
                        .HasForeignKey("NeighborhoodId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("PollCenters")
                        .HasForeignKey("VillageId");

                    b.Navigation("Municipalityd");

                    b.Navigation("Neighborhood");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollRelated", b =>
                {
                    b.HasOne("Domain.Data.Entities.Help", "Help")
                        .WithMany("PollRelateds")
                        .HasForeignKey("HelpId");

                    b.HasOne("Domain.Data.Entities.Voter", "Voter")
                        .WithMany("PollRelateds")
                        .HasForeignKey("VoterId");

                    b.Navigation("Help");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Streets")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Domain.Data.Entities.Neighborhood", "Neighborhood")
                        .WithMany("Streets")
                        .HasForeignKey("NeighborhoodId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("Streets")
                        .HasForeignKey("VillageId");

                    b.Navigation("Municipality");

                    b.Navigation("Neighborhood");

                    b.Navigation("Village");
                });

            modelBuilder.Entity("Domain.Data.Entities.Village", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Villages")
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("Domain.Data.Entities.Voter", b =>
                {
                    b.HasOne("Domain.Data.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Data.Entities.Work", "Work")
                        .WithMany("Voters")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Work");
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
                    b.HasOne("Domain.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Data.Entities.ApplicationUser", null)
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

                    b.HasOne("Domain.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Help", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Blocks");

                    b.Navigation("Kqzregisters");

                    b.Navigation("Neighborhoods");

                    b.Navigation("PollCenters");

                    b.Navigation("Streets");

                    b.Navigation("Villages");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neighborhood", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Kqzregisters");

                    b.Navigation("PollCenters");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Kqzregisters");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Village", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Kqzregisters");

                    b.Navigation("Neighborhoods");

                    b.Navigation("PollCenters");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Domain.Data.Entities.Voter", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Navigation("Voters");
                });
#pragma warning restore 612, 618
        }
    }
}
