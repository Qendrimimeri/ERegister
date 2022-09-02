using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class SpecificReasons
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        //public int? ApplicationUserId { get; set; }


        // Navigation Properties
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
