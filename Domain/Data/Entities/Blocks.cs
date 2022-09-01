using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Blocks
    {
        public int Id { get; set; }

        public string? BlockName { get; set; }

        public int? MunicipalityId { get; set; }




        // Navigation properties
        public ICollection<Addresses>? Addresses { get; set; }

        public Municipalities? Municipalities { get; set; }
    }
}
