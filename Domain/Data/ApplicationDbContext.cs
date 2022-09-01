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

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<ActualStatuses> ActualStatuses { get; set; }
        public DbSet<AdministrativeUnits> AdministrativeUnits { get; set; }
        public DbSet<Blocks> Blocks { get; set; }
        public DbSet<DemandsSpecified> DemandsSpecifieds { get; set; }
        public DbSet<GeneralDemands> GeneralDemands { get; set; }
        public DbSet<GeneralDemands_Users> GeneralDemands_Users { get; set; }
        public DbSet<GeneralReasons> GeneralReasons { get; set; }
        public DbSet<Helps> Helps { get; set; }
        public DbSet<Houses> Houses { get; set; }
        public DbSet<Municipalities> Municipalities { get; set; }
        public DbSet<Neigborhoods> Neigborhoods { get; set; }
        public DbSet<PoliticalSubjects> PoliticalSubjects { get; set; }
        public DbSet<PollCenters> PollCenters { get; set; }
        public DbSet<PollRelated> PollRelateds { get; set; }
        public DbSet<Reasons_Users> Reasons_Users { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<SpecificReasons> SpecificReasons { get; set; }
        public DbSet<Streets> Streets { get; set; }
        public DbSet<StreetSources> StreetSources { get; set; }
        public DbSet<SuccessChances> SuccessChances { get; set; }
        public DbSet<Vilages> Vilages { get; set; }
        public DbSet<Works> Works { get; set; }


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