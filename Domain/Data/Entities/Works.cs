using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Works
    {
        public int Id { get; set; }
        public string? WorkPlace { get; set; }
        public string? Unit { get; set; }
        public string? Duty { get; set; }
    }
}
