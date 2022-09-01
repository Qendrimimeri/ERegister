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

        public int? GeneralDemandId { get; set; }

        public int? ApplicationUserId { get; set; }


        // Navigation Properties
        public GeneralDemands? GeneralDemands { get; set; }

        public ApplicationUser? ApplicationUsers { get; set; }

    }
}
