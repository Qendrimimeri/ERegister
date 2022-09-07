using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }

        // Navigation Properties
        public virtual Municipality? Municipality { get; set; }

        public virtual Vilage? Vilage { get; set; }

        public virtual Neigborhood? Neigborhood { get; set; }

        public virtual House? House { get; set; }

        public virtual Street? Street { get; set; }

        public virtual PollCenter? PollCenter { get; set; }

        public virtual Block? Block { get; set; }


        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
