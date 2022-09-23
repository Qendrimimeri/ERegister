using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            PollRelateds = new HashSet<PollRelated>();
        }

        public string? FullName { get; set; }
        public string? SocialNetwork { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AddressId { get; set; } = null!;
        public string ActualStatus { get; set; } = null!;
        public string WorkId { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
        public virtual Work Work { get; set; } = null!; 
        public virtual ICollection<PollRelated> PollRelateds { get; set; }
    }
}
