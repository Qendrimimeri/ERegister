using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VoterDetailsVM 
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? Neigborhood { get; set; }
        public string? Village { get; set; }
        public string? Block { get; set; }
        public int? HouseNo { get; set; }
        public string? Street   { get; set; }
        public string? PreviousVoter { get; set; }
        public string? MunicipalityName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Facebook { get; set; }
        public int? FamMembers { get; set; }
        public string? PoliticalSubjects { get; set; }
        public string? SuccessChances { get; set; }
        public string? WorkPlace { get; set; }
        public string? AdministrativeUnit { get; set; }
        public string? Duty { get; set; }
        public string? PollCenter { get; set; }
        ///
        public ApplicationUser ApplicationUser { get; set; }
        
        //Votues i Tanishem
        public string? CurrentVoter { get; set; }


        //Gjasat Fillestare
        public string? InitialChances { get; set; }

        //Gjasat Aktuale
        public string? ActualChances { get; set; }

        public string? ActualStatus { get; set; }

        //public string PoliticalSubject { get; set; }
        public string? GeneralDescription { get; set; }

        

    }
}