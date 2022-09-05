using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class GeneralDemands_Users
    {
        public int Id { get; set; }

        // Navigation Properties
        public virtual GeneralDemand? GeneralDemands { get; set; }

        public virtual ApplicationUser? ApplicationUsers { get; set; }

    }
}
