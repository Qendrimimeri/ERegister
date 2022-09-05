using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERegister.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<ActualStatuse> ActualStatuses { get; set; } = null!;
        public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; } = null!;
        public virtual DbSet<Block> Blocks { get; set; } = null!;
        public virtual DbSet<SpecificDemand> DemandsSpecifieds { get; set; } = null!;
        public virtual DbSet<GeneralDemand> GeneralDemands { get; set; } = null!;
        public virtual DbSet<GeneralDemands_Users> GeneralDemands_Users { get; set; } = null!;
        public virtual DbSet<GeneralReason> GeneralReasons { get; set; } = null!;
        public virtual DbSet<Help> Helps { get; set; } = null!;
        public virtual DbSet<House> Houses { get; set; } = null!;
        public virtual DbSet<Municipality> Municipalities { get; set; } = null!;
        public virtual DbSet<Neigborhood> Neigborhoods { get; set; } = null!;
        public virtual DbSet<PoliticalSubject> PoliticalSubjects { get; set; } = null!;
        public virtual DbSet<PollCenter> PollCenters { get; set; } = null!;
        public virtual DbSet<PollRelated> PollRelateds { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SpecificReason> SpecificReasons { get; set; } = null!;
        public virtual DbSet<Street> Streets { get; set; } = null!;
        public virtual DbSet<StreetSource> StreetSources { get; set; } = null!;
        public virtual DbSet<SuccessChance> SuccessChances { get; set; } = null!;
        public virtual DbSet<Vilage> Vilages { get; set; } = null!;
        public virtual DbSet<Work> Works { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    // Configuring Many to many relationship with fluent API
        //    builder.Entity<GeneralDemands_Users>()
        //        // general demands user
        //        .HasOne(GD => GD.GeneralDemands)
        //        // GDU => general demand user
        //        .WithMany(GDU => GDU.GeneralDemands_Users)
        //        // GDI => general Demand Id 
        //        .HasForeignKey(GDI => GDI.GeneralDemandId);

        //    builder.Entity<GeneralDemands_Users>()
        //        .HasOne(U => U.ApplicationUsers)

        //        .WithMany(GDU => GDU.GeneralDemands_Users)
        //        // UI => User Id
        //        .HasForeignKey(UI => UI.ApplicationUserId);

        //    // Reasons And Users Many to Many relationship
        //    builder.Entity<Reasons_Users>()
        //        .HasOne(R => R.GeneralReasons)
        //        .WithMany(RS => RS.Reasons_Users)
        //        .HasForeignKey(RI => RI.GeneralReasonId);

        //    builder.Entity<Reasons_Users>()
        //        .HasOne(U => U.ApplicationUsers)
        //        .WithMany(RS => RS.Reasons_Users)
        //        .HasForeignKey(UI => UI.ApplicationUserId);
        //}
    }
    
}