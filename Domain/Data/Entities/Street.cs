using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Street
    {
        public int Id { get; set; }

        public string? StreetName { get; set; }

        // Navigation Properties
        public virtual StreetSource? StreetSource { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
