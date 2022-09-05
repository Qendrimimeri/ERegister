using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Block
    {
        public int Id { get; set; }

        public string? BlockName { get; set; }

        // Navigation properties
        public virtual Municipality? Municipality { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }

    }
}
