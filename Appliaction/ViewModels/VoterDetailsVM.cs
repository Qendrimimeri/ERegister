using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VoterDetailsVM : RegisterVM
    {
        public string Id { get; set; }
        public string? Neigborhood { get; set; }
        public string? Village { get; set; }
        public string? Block { get; set; }
        public string? GeneralReason { get; set; }
        public string? MunicipalityName { get; set; }
        public string? SpecificReason { get; set; }
        public bool? CanYouManage { get; set; }
        public string? ActivitiesYourPlan { get; set; }
        public bool? NeedHelp { get; set; }
        public string? SpecificDemand { get; set; }
        public string? GeneralDemands { get; set; }
        public string? GeneralDescription { get; set; }
        public string? PoliticalSubjects { get; set; }
    }
}
