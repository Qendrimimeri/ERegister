using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class GeneralDemandsUser
    {
        public int Id { get; set; }

        public int? GeneralDemandId { get; set; }

        public int? ApplicationUserId { get; set; }


        // Navigation Properties
        public ICollection<GeneralDemands>? GeneralDemands { get; set; }

        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }

    }
}
