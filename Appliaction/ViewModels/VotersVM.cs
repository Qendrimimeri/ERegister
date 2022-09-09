using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliaction.ViewModels
{
    public class VoterDetailsVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Neighborhoods { get; set; }
        public int Village { get; set; }

        public string Blocks { get; set; }
        public string HouseNo { get; set; }
        public int Email { get; set; }
        public string Facebook { get; set; }
        public int FamMembers { get; set; }
        public int PoliticalSubject { get; set; }
        public int SuccessChances { get; set; }
        public string WorkPlace { get; set; }
        public int AdministrativeUnit { get; set; }
        public string Duty { get; set; }


    }
}