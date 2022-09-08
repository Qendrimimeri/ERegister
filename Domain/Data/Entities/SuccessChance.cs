using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class SuccessChance
    {
        public SuccessChance()
        {
            PollRelateds = new HashSet<PollRelated>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<PollRelated> PollRelateds { get; set; }
    }
}
