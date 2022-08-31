using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class ActualStatuses
    {
        // Scalar Properties
        public int Id { get; set; }

        // -> perfunduar, ne proces, pa perfunduar
        public string? Description { get; set; }


        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
