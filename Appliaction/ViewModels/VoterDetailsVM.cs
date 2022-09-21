using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VoterDetailsVM
    {
        //Pjesa e Tabeles
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Neighborhoods { get; set; }
        public int Village { get; set; }
        public string Blocks { get; set; }
        public string HouseNo { get; set; }
        public string PhoneNumber { get; set; }
        public int Email { get; set; }
        public string Facebook { get; set; }
        public int FamMembers { get; set; }
        public int PoliticalSubject { get; set; }
        public int SuccessChances { get; set; }
        public string WorkPlace { get; set; }
        public int AdministrativeUnit { get; set; }
        public string Duty { get; set; }
        public string PollCenter { get; set; }
        //Pjesa e Pyetesorit 
        public string? GeneralReason { get; set; }
        public string? SpecificReason { get; set; }
        public bool? CanYouManage { get; set; }
        public string? ActivitiesYouPlan { get; set; }
        public bool? NeedHelp { get; set; }
        public string? GeneralDemand { get; set; }
        public string? SpecificDemand { get; set; }
        public string? GeneralDescription { get; set; }






    }
}