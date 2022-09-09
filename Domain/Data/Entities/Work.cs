using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Work
    {
        public Work()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public string Id { get; set; } = null!;
        public string? WorkPlace { get; set; }
        public string? Duty { get; set; }
        public string? AdministrativeUnit { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
