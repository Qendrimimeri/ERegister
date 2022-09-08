using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Work
    {
        public Work()
        {
            AspNetUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string? WorkPlace { get; set; }
        public string? Duty { get; set; }
        public int? AdministrativeUnitId { get; set; }

        public virtual AdministrativeUnit? AdministrativeUnit { get; set; }
        public virtual ICollection<ApplicationUser> AspNetUsers { get; set; }
    }
}
