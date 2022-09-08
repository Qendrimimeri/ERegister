using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class ActualStatus
    {
        public ActualStatus()
        {
            AspNetUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ApplicationUser> AspNetUsers { get; set; }
    }
}
