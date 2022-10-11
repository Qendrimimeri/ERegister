using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Services
{
    public class ErrorHandler
    {
        public static string? SectionName { get; set; } = "ExceptionHandlerView";
        public string? RazorView { get; set; }
    }
}
