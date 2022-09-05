using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class GeneralDemand
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        // Navigation Properties
        public virtual ICollection<GeneralDemands_Users>? GeneralDemands_Users { get; set; }
    }
}
