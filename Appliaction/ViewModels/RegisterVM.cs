using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliaction.ViewModels
{
    public class RegisterVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public int Municipality { get; set; }
        public int Village { get; set; }
        public int StreetBlock { get; set; }
        public int HouseNo { get; set; }
        public string WorkPlace { get; set; }
        public int AdministrativeUnit { get; set; }
        public string Duty { get; set; }
        public int FamMembers { get; set; }
        public int SuccessChance { get; set; }
        public int PoliticalSubject { get; set; }
        public int PollCenter { get; set; }
    }
}
