using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Municipality
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        //Navigation propertiees
        public virtual Region? Region { get; set; }

        public virtual ICollection<Address>? Addresses { get; set; }

        public virtual ICollection<Block>? Blocks { get; set; }

        public virtual ICollection<Neigborhood>? Neigborhoods { get; set; }

        public virtual ICollection<Vilage>? Vilages { get; set; }
    }
}
