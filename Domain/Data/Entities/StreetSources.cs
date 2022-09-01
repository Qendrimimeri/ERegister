using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class StreetSources
    {
        public int Id { get; set; }

        public string? SourceName { get; set; }



        // Navigation Properties
        public ICollection<Streets>? Streets { get; set; }
    }
}
