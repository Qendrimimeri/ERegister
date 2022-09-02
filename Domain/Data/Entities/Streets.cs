using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Streets
    {
        public int Id { get; set; }

        public string? StreetName { get; set; }

        //public int? StreetSourceId { get; set; }



        // Navigation Properties
        public StreetSources? StreetSource { get; set; }

        public ICollection<Addresses>? Addresses { get; set; }
    }
}
