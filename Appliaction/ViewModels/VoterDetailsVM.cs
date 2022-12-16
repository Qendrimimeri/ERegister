﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Application.ViewModels
{
    public class VoterDetailsVM : RegisterVM
    {
        [ValidateNever]
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        [ValidateNever]
        public string? Neigborhood { get; set; }

        [ValidateNever]
        public string? Village { get; set; }

        [ValidateNever]
        public string? Block { get; set; }


        [ValidateNever]
        public string? Reason { get; set; }


        [ValidateNever]
        public string? MunicipalityName { get; set; }
        public string? PollCenter { get; set; }


        [ValidateNever]
        public int? CanYouManage { get; set; }

        [ValidateNever]
        public string? ActivitiesYourPlan { get; set; }

        [ValidateNever]
        public int? NeedHelp { get; set; }


        [ValidateNever]
        public string? Demands { get; set; }

        [ValidateNever]
        public string? Description { get; set; }

        [ValidateNever]
        public string? PoliticalSubjects { get; set; }

        [ValidateNever]
        public string? InitialChance { get; set; }

        public string? ActualChances { get; set; }
        public string? ActualStatus { get; set; }


        [ValidateNever]
        public string? CurrentVoter { get; set; }

        [ValidateNever]
        public string? PreviousVoter { get; set; }

        [ValidateNever]
        public int? VotersNumber { get; set; }

        [ValidateNever]
        public string? FacebookLink { get; set; }
        //public int? FamMembersNumber { get; set; }
    }
}