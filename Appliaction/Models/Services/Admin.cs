using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Services
{
    public class Admin
    {
        public static string SectionName { get; set; } = "Admin";

        public string? FirstName { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
