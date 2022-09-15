using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PersonVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Village { get; set; }
        public string City { get; set; }
        public int? FamMembers { get; set; }
    }
}
