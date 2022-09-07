using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            GeneralDemandsUsers = new HashSet<GeneralDemandsUser>();
            PollRelateds = new HashSet<PollRelated>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SocialNetwork { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AddressId { get; set; }
        public int ActualStatusId { get; set; }
        public int WorkId { get; set; }

        public virtual ActualStatus ActualStatus { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
        public virtual Work Work { get; set; } = null!;
        public virtual ICollection<GeneralDemandsUser> GeneralDemandsUsers { get; set; }
        public virtual ICollection<PollRelated> PollRelateds { get; set; }
    }
}
