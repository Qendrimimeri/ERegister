using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Services
{
    public class Reasons
    {
        public static string SectionName { get; set; } = "GeneralReasons";

        public string? Familja { get; set; }

        public string? PunaBiznesi { get; set; }

        public string? BindjaPolitike { get; set; }

        public string? Shoqëria { get; set; }
    }
}
