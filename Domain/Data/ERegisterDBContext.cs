using System;
using System.Collections.Generic;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Data
{
    public partial class ERegisterDBContext : DbContext
    {
        public ERegisterDBContext()
        {
        }

        public ERegisterDBContext(DbContextOptions<ERegisterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualStatus> ActualStatuses { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<Block> Blocks { get; set; } = null!;
        public virtual DbSet<GeneralDemand> GeneralDemands { get; set; } = null!;
        public virtual DbSet<GeneralDemandsUser> GeneralDemandsUsers { get; set; } = null!;
        public virtual DbSet<GeneralReason> GeneralReasons { get; set; } = null!;
        public virtual DbSet<Help> Helps { get; set; } = null!;
        public virtual DbSet<Municipality> Municipalities { get; set; } = null!;
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
        public virtual DbSet<PoliticalSubject> PoliticalSubjects { get; set; } = null!;
        public virtual DbSet<PollCenter> PollCenters { get; set; } = null!;
        public virtual DbSet<PollRelated> PollRelateds { get; set; } = null!;
        public virtual DbSet<SpecificDemand> SpecificDemands { get; set; } = null!;
        public virtual DbSet<SpecificReason> SpecificReasons { get; set; } = null!;
        public virtual DbSet<Street> Streets { get; set; } = null!;
        public virtual DbSet<StreetSource> StreetSources { get; set; } = null!;
        public virtual DbSet<SuccessChance> SuccessChances { get; set; } = null!;
        public virtual DbSet<Village> Villages { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=ERegisterDB; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualStatus>(entity =>
            {
                entity.ToTable("ActualStatus");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Block)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.BlockId)
                    .HasConstraintName("FK__Addresses__Block__66603565");

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Addresses__Munic__6383C8BA");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK__Addresses__Neigh__656C112C");

                entity.HasOne(d => d.PollCenter)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PollCenterId)
                    .HasConstraintName("FK__Addresses__PollC__68487DD7");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK__Addresses__Stree__6754599E");

                entity.HasOne(d => d.Village)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.VillageId)
                    .HasConstraintName("FK__Addresses__Villa__6477ECF3");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK__Addresses__WorkI__693CA210");
            });

            modelBuilder.Entity<AdministrativeUnit>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

            });


            modelBuilder.Entity<Block>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Blocks)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Blocks__Municipa__5070F446");
            });

            modelBuilder.Entity<GeneralDemand>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<GeneralDemandsUser>(entity =>
            {
                entity.ToTable("GeneralDemands_Users");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.GeneralDemand)
                    .WithMany(p => p.GeneralDemandsUsers)
                    .HasForeignKey(d => d.GeneralDemandId)
                    .HasConstraintName("FK__GeneralDe__Gener__02FC7413");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GeneralDemandsUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__GeneralDe__UserI__03F0984C");
            });

            modelBuilder.Entity<GeneralReason>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Neighborhoods)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Neighborh__Munic__534D60F1");
            });

            modelBuilder.Entity<PoliticalSubject>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PollCenter>(entity =>
            {
                entity.Property(e => e.CenterName).HasMaxLength(50);

                entity.Property(e => e.CenterNumber).HasMaxLength(50);

                entity.HasOne(d => d.Municipalityd)
                    .WithMany(p => p.PollCenters)
                    .HasForeignKey(d => d.MunicipalitydId)
                    .HasConstraintName("FK__PollCente__Munic__5BE2A6F2");
            });

            modelBuilder.Entity<PollRelated>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.GeneralReasonId).HasColumnName("GeneralReasonID");

                entity.Property(e => e.SuccessChancesId).HasColumnName("SuccessChancesID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.GeneralReason)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.GeneralReasonId)
                    .HasConstraintName("FK__PollRelat__Gener__7C4F7684");

                entity.HasOne(d => d.PoliticalSubject)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.PoliticalSubjectId)
                    .HasConstraintName("FK__PollRelat__Polit__7A672E12");

                entity.HasOne(d => d.SpecificDemand)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.SpecificDemandId)
                    .HasConstraintName("FK__PollRelat__Speci__7E37BEF6");

                entity.HasOne(d => d.SpecificReason)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.SpecificReasonId)
                    .HasConstraintName("FK__PollRelat__Speci__7D439ABD");

                entity.HasOne(d => d.SuccessChances)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.SuccessChancesId)
                    .HasConstraintName("FK__PollRelat__Succe__7B5B524B");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PollRelateds)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PollRelat__UserI__797309D9");
            });

            modelBuilder.Entity<SpecificDemand>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<SpecificReason>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Streets__Municip__59063A47");

                entity.HasOne(d => d.StreetSource)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.StreetSourceId)
                    .HasConstraintName("FK__Streets__StreetS__5812160E");
            });

            modelBuilder.Entity<StreetSource>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SuccessChance>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Village>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Municipality)
                    .WithMany(p => p.Villages)
                    .HasForeignKey(d => d.MunicipalityId)
                    .HasConstraintName("FK__Villages__Munici__4D94879B");
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.Property(e => e.Duty).HasMaxLength(50);

                entity.Property(e => e.WorkPlace).HasMaxLength(50);

                entity.HasOne(d => d.AdministrativeUnit)
                    .WithMany(p => p.Works)
                    .HasForeignKey(d => d.AdministrativeUnitId)
                    .HasConstraintName("FK__Works__Administr__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
