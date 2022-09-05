using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Vilage
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? MunicipalityId { get; set; }


        // Navigation properties
        public virtual Municipality? Municipality { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
