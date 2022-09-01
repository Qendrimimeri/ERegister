using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Municipalities
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? RegionId { get; set; }


        //Navigation propertiees
        public Regions? Regions { get; set; }


        public ICollection<Addresses>? Addresses { get; set; }

        public ICollection<Blocks>? Blocks { get; set; }

        public ICollection<Neigborhoods>? Neigborhoods { get; set; }

        public ICollection<Vilages>? Vilages { get; set; }
    }
}
