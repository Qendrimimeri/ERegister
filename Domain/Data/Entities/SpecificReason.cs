using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class SpecificReason
    {
        public SpecificReason()
        {
            PollRelateds = new HashSet<PollRelated>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<PollRelated> PollRelateds { get; set; }
    }
}
