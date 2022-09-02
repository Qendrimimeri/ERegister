using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class DemandsSpecified
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        //public int? ApplicationUserId { get; set; }


        // Navigation Properties
        public ApplicationUser? AppliactionUser { get; set; }
    }
}
