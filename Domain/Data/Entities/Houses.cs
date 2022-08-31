using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Houses
    {
        public int Id { get; set; }

        public string? Number { get; set; }

        public string? BlockNo { get; set; }


        public ICollection<Addresses>? Addresses { get; set; }

    }
}
