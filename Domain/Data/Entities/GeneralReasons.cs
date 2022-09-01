using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class GeneralReasons
    {
        public int Id { get; set; }

        public string? Description { get; set; }



        // Navigation Properties
        public ICollection<Reasons_Users>? Reasons_Users { get; set; }
    }
}
