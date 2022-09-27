using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RegisterVM
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public int Municipality { get; set; }
        public int Village { get; set; }
        public int Neigborhood { get; set; }
        public int Street { get; set; }
        public int Block { get; set; }
        public int? HouseNo { get; set; }
        public string WorkPlace { get; set; }
        public string AdministrativeUnit { get; set; }
        public string Duty { get; set; }
        public int FamMembers { get; set; }
        public string SuccessChance { get; set; }
        public int PoliticalSubject { get; set; }
        public string PollCenter { get; set; }
    }
}
