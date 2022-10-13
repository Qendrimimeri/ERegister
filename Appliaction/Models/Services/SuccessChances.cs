using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Services
{
    public class SuccessChances
    {
        public static string? SectionName { get; set; } = "SuccessChances";
        
        public string? Low { get; set; }

        public string? LowMidd { get; set; }

        public string? Midd { get; set; }

        public string? MiddHigh { get; set; }

        public string? High { get; set; }
    }
}
