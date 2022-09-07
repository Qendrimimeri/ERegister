using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class AdministrativeUnit
    {
        public AdministrativeUnit()
        {
            Works = new HashSet<Work>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Work> Works { get; set; }
    }
}
