using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Municipality
    {
        public Municipality()
        {
            Addresses = new HashSet<Address>();
            Blocks = new HashSet<Block>();
            Kqzregisters = new HashSet<Kqzregister>();
            Neighborhoods = new HashSet<Neighborhood>();
            PollCenters = new HashSet<PollCenter>();
            Streets = new HashSet<Street>();
            Villages = new HashSet<Village>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Block> Blocks { get; set; }
        public virtual ICollection<Kqzregister> Kqzregisters { get; set; }
        public virtual ICollection<Neighborhood> Neighborhoods { get; set; }
        public virtual ICollection<PollCenter> PollCenters { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
        public virtual ICollection<Village> Villages { get; set; }
    }
}
