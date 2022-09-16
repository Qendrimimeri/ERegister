using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PoliticalOfficalVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? Municipality { get; set; }
        public int? Village { get; set; }
        public int? Neigborhood { get; set; }
        public int? Street { get; set; }
        public int? Block { get; set; }
        public int? HouseNo { get; set; }
        public string? Role { get; set; }
        public string? PollCenter { get; set; }
    }
}
