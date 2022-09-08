using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class StreetSource
    {
        public StreetSource()
        {
            Streets = new HashSet<Street>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}
