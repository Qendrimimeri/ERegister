using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class GeneralReason
    {
        public int Id { get; set; }

        public string? Description { get; set; }


        // Navigation Properties
        public virtual ICollection<PollRelated>? PollRelateds { get; set; }
    }
}
