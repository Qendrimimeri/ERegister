using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        // Scalar Properties
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? SocialNetwork { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public virtual Address? Address { get; set; }

        public virtual ActualStatuse? ActualStatus { get; set; }

        public virtual Work? Work { get; set; }

        public virtual ICollection<GeneralDemands_Users>? GeneralDemands_Users { get; set; }

    }
}
