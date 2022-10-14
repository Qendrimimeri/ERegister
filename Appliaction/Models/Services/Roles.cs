using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Services
{
    public class Roles
    {
        public static string? SectionName { get; set; } = "Roles";

        public string? KryetarIPartise { get; set; }

        public string? KryetarIKomunes { get; set; }

        public string? KryetarIFshatit { get; set; }

        public string? AnetarIThjeshte { get; set; }
    }
}
