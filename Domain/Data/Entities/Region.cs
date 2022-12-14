using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Region
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        // Navigation Properties
        public virtual ICollection<Municipality>? Municipalities { get; set; }
    }
}
