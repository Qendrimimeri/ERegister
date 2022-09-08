using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class GeneralDemand
    {
        public GeneralDemand()
        {
            GeneralDemandsUsers = new HashSet<GeneralDemandsUser>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<GeneralDemandsUser> GeneralDemandsUsers { get; set; }
    }
}
