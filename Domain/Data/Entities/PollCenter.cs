using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class PollCenter
    {
        public int Id { get; set; }

        public int? CenterNumber { get; set; }

        public string? CenterName { get; set; }



        // Navigation properties
        public virtual ICollection<Address>? Addresses { get; set; }
    }
}
