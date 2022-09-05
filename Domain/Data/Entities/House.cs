using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class House
    {
        public int Id { get; set; }

        public string? Number { get; set; }



        // Navigation Properties 
        public virtual ICollection<Address>? Addresses { get; set; }

    }
}
