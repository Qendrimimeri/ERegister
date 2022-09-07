using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class SpecificDemand
    {
        public int Id { get; set; }

        public string? Description { get; set; }



        // Navigation Properties
        public virtual ICollection<ApplicationUser>? AppliactionUsers { get; set; }
        public virtual ICollection<PollRelated>? PollRelateds { get; set; }
    }
}
