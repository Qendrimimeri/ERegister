using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Toaster
    {
        public static string? SectionName { get; set; } = "Toaster";
        public string? Success { get; set; }
        public string? Error { get; set; }
        public string? Info { get; set; }
        public string? Warning { get; set; }
    }
}
