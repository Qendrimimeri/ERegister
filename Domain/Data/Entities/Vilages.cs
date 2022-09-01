using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Vilages
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? MunicipalityId { get; set; }


        // Navigation properties
        public Municipalities? Municipalities { get; set; }

        public ICollection<Addresses>? Addresses { get; set; }
    }
}
