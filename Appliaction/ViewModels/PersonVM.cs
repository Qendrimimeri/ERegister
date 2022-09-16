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
        public string? FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? MunicipalityName { get; set; }
        public string? PollCenter { get; set; }
        public int? VotersNumber { get; set; }
        
        //Votues Paraprak
        public string PreviousVoter { get; set; }
        //Votues i Tanishem
        public string CurrentVoter { get; set; }
   

        //Gjasat Fillestare
        public string  InitialChances { get; set; }

        //Gjasat Aktuale
        public string ActualChances { get; set; }
        
        public string? ActualStatus { get; set; }
    }
}
