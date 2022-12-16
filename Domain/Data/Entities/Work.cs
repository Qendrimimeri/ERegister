using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Work
    {
        public Work()
        {
            Voters = new HashSet<Voter>();
        }

        public string Id { get; set; } = null!;
        public string? WorkPlace { get; set; }
        public string? Duty { get; set; }
        public string? AdministrativeUnit { get; set; }

        public virtual ICollection<Voter> Voters { get; set; }
    }
}
