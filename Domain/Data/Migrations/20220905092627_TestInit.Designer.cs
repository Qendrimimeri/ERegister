﻿// <auto-generated />
using System;
using ERegister.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ERegister.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220905092627_TestInit")]
    partial class TestInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdministrativeUnitWork", b =>
                {
                    b.Property<int>("AdministrativeUnitsId")
                        .HasColumnType("int");

                    b.Property<int>("WorksId")
                        .HasColumnType("int");

                    b.HasKey("AdministrativeUnitsId", "WorksId");

                    b.HasIndex("WorksId");

                    b.ToTable("AdministrativeUnitWork");
                });

            modelBuilder.Entity("Domain.Data.Entities.ActualStatuse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActualStatuses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BlockId")
                        .HasColumnType("int");

                    b.Property<int?>("HouseId")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.Property<int?>("NeigborhoodId")
                        .HasColumnType("int");

                    b.Property<int?>("PollCenterId")
                        .HasColumnType("int");

                    b.Property<int?>("StreetId")
                        .HasColumnType("int");

                    b.Property<int?>("VilageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.HasIndex("HouseId");

                    b.HasIndex("MunicipalityId");

                    b.HasIndex("NeigborhoodId");

                    b.HasIndex("PollCenterId");

                    b.HasIndex("StreetId");

                    b.HasIndex("VilageId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.AdministrativeUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdministrativeUnits");
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BlockName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MunicipalityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalityId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralDemand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralDemands");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralDemands_Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("GeneralDemandsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUsersId");

                    b.HasIndex("GeneralDemandsId");

                    b.ToTable("GeneralDemands_Users");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralReasons");
                });

            modelBuilder.Entity("Domain.Data.Entities.Help", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ActivitiesYouPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CanYouManage")
                        .HasColumnType("bit");

                    b.Property<bool>("NeedHelp")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Helps");
                });

            modelBuilder.Entity("Domain.Data.Entities.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neigborhood", b =>
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

                    b.ToTable("Neigborhoods");
                });

            modelBuilder.Entity("Domain.Data.Entities.PoliticalSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PoliticalSubjects");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CenterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CenterNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PollCenters");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollRelated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FamMember")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralDemandId")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralReasonId")
                        .HasColumnType("int");

                    b.Property<int?>("HelpId")
                        .HasColumnType("int");

                    b.Property<int?>("MyPropertyId")
                        .HasColumnType("int");

                    b.Property<int?>("PoliticalSubjectsId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecificReasonId")
                        .HasColumnType("int");

                    b.Property<int?>("SuccessChancesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("GeneralDemandId");

                    b.HasIndex("GeneralReasonId");

                    b.HasIndex("HelpId");

                    b.HasIndex("MyPropertyId");

                    b.HasIndex("PoliticalSubjectsId");

                    b.HasIndex("SpecificReasonId");

                    b.HasIndex("SuccessChancesId");

                    b.ToTable("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Domain.Data.Entities.SpecificDemand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DemandsSpecifieds");
                });

            modelBuilder.Entity("Domain.Data.Entities.SpecificReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("SpecificReasons");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StreetSourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreetSourceId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Domain.Data.Entities.StreetSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SourceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StreetSources");
                });

            modelBuilder.Entity("Domain.Data.Entities.SuccessChance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SuccessChances");
                });

            modelBuilder.Entity("Domain.Data.Entities.Vilage", b =>
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

                    b.ToTable("Vilages");
                });

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdministrativeUnitId")
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("ActualStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SocialNetwork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecificDemandId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkId")
                        .HasColumnType("int");

                    b.HasIndex("ActualStatusId");

                    b.HasIndex("AddressId");

                    b.HasIndex("SpecificDemandId");

                    b.HasIndex("WorkId");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AdministrativeUnitWork", b =>
                {
                    b.HasOne("Domain.Data.Entities.AdministrativeUnit", null)
                        .WithMany()
                        .HasForeignKey("AdministrativeUnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Data.Entities.Work", null)
                        .WithMany()
                        .HasForeignKey("WorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.HasOne("Domain.Data.Entities.Block", "Block")
                        .WithMany("Addresses")
                        .HasForeignKey("BlockId");

                    b.HasOne("Domain.Data.Entities.House", "House")
                        .WithMany("Addresses")
                        .HasForeignKey("HouseId");

                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Addresses")
                        .HasForeignKey("MunicipalityId");

                    b.HasOne("Domain.Data.Entities.Neigborhood", "Neigborhood")
                        .WithMany("Addresses")
                        .HasForeignKey("NeigborhoodId");

                    b.HasOne("Domain.Data.Entities.PollCenter", "PollCenter")
                        .WithMany("Addresses")
                        .HasForeignKey("PollCenterId");

                    b.HasOne("Domain.Data.Entities.Street", "Street")
                        .WithMany("Addresses")
                        .HasForeignKey("StreetId");

                    b.HasOne("Domain.Data.Entities.Vilage", "Vilage")
                        .WithMany("Addresses")
                        .HasForeignKey("VilageId");

                    b.Navigation("Block");

                    b.Navigation("House");

                    b.Navigation("Municipality");

                    b.Navigation("Neigborhood");

                    b.Navigation("PollCenter");

                    b.Navigation("Street");

                    b.Navigation("Vilage");
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Blocks")
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralDemands_Users", b =>
                {
                    b.HasOne("Domain.Data.Entities.ApplicationUser", "ApplicationUsers")
                        .WithMany("GeneralDemands_Users")
                        .HasForeignKey("ApplicationUsersId");

                    b.HasOne("Domain.Data.Entities.GeneralDemand", "GeneralDemands")
                        .WithMany("GeneralDemands_Users")
                        .HasForeignKey("GeneralDemandsId");

                    b.Navigation("ApplicationUsers");

                    b.Navigation("GeneralDemands");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.HasOne("Domain.Data.Entities.Region", "Region")
                        .WithMany("Municipalities")
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neigborhood", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Neigborhoods")
                        .HasForeignKey("MunicipalityId");

                    b.Navigation("Municipality");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollRelated", b =>
                {
                    b.HasOne("Domain.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Data.Entities.GeneralDemand", "GeneralDemand")
                        .WithMany()
                        .HasForeignKey("GeneralDemandId");

                    b.HasOne("Domain.Data.Entities.GeneralReason", null)
                        .WithMany("PollRelateds")
                        .HasForeignKey("GeneralReasonId");

                    b.HasOne("Domain.Data.Entities.Help", "Help")
                        .WithMany("PollRelateds")
                        .HasForeignKey("HelpId");

                    b.HasOne("Domain.Data.Entities.SpecificDemand", "MyProperty")
                        .WithMany("PollRelateds")
                        .HasForeignKey("MyPropertyId");

                    b.HasOne("Domain.Data.Entities.PoliticalSubject", "PoliticalSubjects")
                        .WithMany("PollRelateds")
                        .HasForeignKey("PoliticalSubjectsId");

                    b.HasOne("Domain.Data.Entities.SpecificReason", "SpecificReason")
                        .WithMany()
                        .HasForeignKey("SpecificReasonId");

                    b.HasOne("Domain.Data.Entities.SuccessChance", "SuccessChances")
                        .WithMany("PollRelateds")
                        .HasForeignKey("SuccessChancesId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("GeneralDemand");

                    b.Navigation("Help");

                    b.Navigation("MyProperty");

                    b.Navigation("PoliticalSubjects");

                    b.Navigation("SpecificReason");

                    b.Navigation("SuccessChances");
                });

            modelBuilder.Entity("Domain.Data.Entities.SpecificReason", b =>
                {
                    b.HasOne("Domain.Data.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.HasOne("Domain.Data.Entities.StreetSource", "StreetSource")
                        .WithMany("Streets")
                        .HasForeignKey("StreetSourceId");

                    b.Navigation("StreetSource");
                });

            modelBuilder.Entity("Domain.Data.Entities.Vilage", b =>
                {
                    b.HasOne("Domain.Data.Entities.Municipality", "Municipality")
                        .WithMany("Vilages")
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.HasOne("Domain.Data.Entities.ActualStatuse", "ActualStatus")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ActualStatusId");

                    b.HasOne("Domain.Data.Entities.Address", "Address")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("AddressId");

                    b.HasOne("Domain.Data.Entities.SpecificDemand", null)
                        .WithMany("AppliactionUsers")
                        .HasForeignKey("SpecificDemandId");

                    b.HasOne("Domain.Data.Entities.Work", "Work")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("WorkId");

                    b.Navigation("ActualStatus");

                    b.Navigation("Address");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("Domain.Data.Entities.ActualStatuse", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("Domain.Data.Entities.Address", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("Domain.Data.Entities.Block", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralDemand", b =>
                {
                    b.Navigation("GeneralDemands_Users");
                });

            modelBuilder.Entity("Domain.Data.Entities.GeneralReason", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Help", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.House", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Municipality", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Blocks");

                    b.Navigation("Neigborhoods");

                    b.Navigation("Vilages");
                });

            modelBuilder.Entity("Domain.Data.Entities.Neigborhood", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.PoliticalSubject", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.PollCenter", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Region", b =>
                {
                    b.Navigation("Municipalities");
                });

            modelBuilder.Entity("Domain.Data.Entities.SpecificDemand", b =>
                {
                    b.Navigation("AppliactionUsers");

                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Street", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.StreetSource", b =>
                {
                    b.Navigation("Streets");
                });

            modelBuilder.Entity("Domain.Data.Entities.SuccessChance", b =>
                {
                    b.Navigation("PollRelateds");
                });

            modelBuilder.Entity("Domain.Data.Entities.Vilage", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Domain.Data.Entities.Work", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("Domain.Data.Entities.ApplicationUser", b =>
                {
                    b.Navigation("GeneralDemands_Users");
                });
#pragma warning restore 612, 618
        }
    }
}
