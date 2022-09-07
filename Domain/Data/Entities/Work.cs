using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Work
    {
        public int Id { get; set; }

        public string? WorkPlace { get; set; }

        public string? AdministrativeUnitId { get; set; }

        public string? Duty { get; set; }


        // Navigation Properties
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }

        public virtual ICollection<AdministrativeUnit>? AdministrativeUnits { get; set; }
    }
}
