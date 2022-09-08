using System;
using System.Collections.Generic;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualStatus> ActualStatuses { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; } = null!;
        public virtual DbSet<ApplicationUser> AspNetUsers { get; set; } = null!;
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
    }
}
