using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class PollCenters
    {
        public int Id { get; set; }

        public int? CenterNumber { get; set; }

        public string? CenterName { get; set; }



        // Navigation properties
        public ICollection<Addresses>? Addresses { get; set; }
    }
}
