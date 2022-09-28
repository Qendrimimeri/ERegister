﻿// <auto-generated />
using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

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
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ActualStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("ImgPath")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("SocialNetwork")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("WorkId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("WorkId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Domain.Data.Entities.Help", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActivitiesYouPlan")
                        .HasColumnType("longtext");

                    b.Property<bool?>("CanYouManage")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("NeedHelp")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Helps");
                });

            modelBuilder.Entity("Domain.Data.Entities.Kqzregister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DataCreated")
                        .HasColumnType("longtext");

                    b.Property<string>("ElectionType")
                        .HasColumnType("longtext");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("NoOfvotes")
                        .HasColumnType("int");

                    b.Property<int?>("PoliticialSubjectId")
                        .HasColumnType("int");

                    b.Property<int?>("PollCenterId")
                        .HasColumnType("int");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeighborhoodId");

                    b.HasIndex("PoliticialSubjectId");

                    b.HasIndex("PollCenterId");

                    b.HasIndex("VillageId");

                    b.ToTable("Kqzregisters");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("VillageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("VillageId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Domain.Data.Entities.PoliticalSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PoliticalSubjects");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CenterName")
                        .HasColumnType("longtext");

                    b.Property<string>("CenterNumber")
                        .HasColumnType("longtext");

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

                    b.Property<string>("ApplicationUsersId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FamMembers")
                        .HasColumnType("int");

                    b.Property<string>("GeneralDemand")
                        .HasColumnType("longtext");

                    b.Property<string>("GeneralDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("GeneralReason")
                        .HasColumnType("longtext");

                    b.Property<int?>("HelpId")
                        .HasColumnType("int");

                    b.Property<int?>("PoliticialSubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SpecificDemand")
                        .HasColumnType("longtext");

                    b.Property<string>("SpecificReason")
                        .HasColumnType("longtext");

                    b.Property<string>("SuccessChances")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUsersId");

                    b.HasIndex("HelpId");

                    b.HasIndex("PoliticialSubjectId");

                    b.ToTable("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<string>("StreetSource")
                        .HasColumnType("longtext");

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

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Villages");
                });

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AdministrativeUnit")
                        .HasColumnType("longtext");

                    b.Property<string>("Duty")
                        .HasColumnType("longtext");

                    b.Property<string>("WorkPlace")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

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

                    b.HasOne("Domain.Data.Entities.Work", "Work")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Work");
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

                    b.HasOne("Domain.Data.Entities.PoliticalSubject", "PoliticialSubject")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("PoliticialSubjectId");

                    b.HasOne("Domain.Data.Entities.PollCenter", "PollCenter")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("PollCenterId");

                    b.HasOne("Domain.Data.Entities.Village", "Village")
                        .WithMany("Kqzregisters")
                        .HasForeignKey("VillageId");

                    b.Navigation("Municipality");

                    b.Navigation("Neighborhood");

                    b.Navigation("PoliticialSubject");

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
                    b.HasOne("Domain.Data.Entities.ApplicationUser", "ApplicationUsers")
                        .WithMany("PollRelateds")
                        .HasForeignKey("ApplicationUsersId");

                    b.HasOne("Domain.Data.Entities.Help", "Help")
                        .WithMany("PollRelateds")
                        .HasForeignKey("HelpId");

                    b.HasOne("Domain.Data.Entities.PoliticalSubject", "PoliticialSubject")
                        .WithMany("PollRelateds")
                        .HasForeignKey("PoliticialSubjectId");

                    b.Navigation("ApplicationUsers");

                    b.Navigation("Help");

                    b.Navigation("PoliticialSubject");
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

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.Navigation("PollRelateds");
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

            modelBuilder.Entity("Domain.Data.Entities.PoliticalSubject", b =>
                {
                    b.Navigation("Kqzregisters");

                    b.Navigation("PollRelateds");
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

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Navigation("ApplicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
