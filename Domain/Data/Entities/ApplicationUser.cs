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

        public int? AddressId { get; set; }

        public int? ActualStatusId { get; set; }

        public int? WorkId { get; set; }



        // Navigation Properties

        public ICollection<GeneralDemands_Users>? GeneralDemands_Users { get; set; }

        public ICollection<Reasons_Users>? Reasons_Users { get; set; }
    }
}
