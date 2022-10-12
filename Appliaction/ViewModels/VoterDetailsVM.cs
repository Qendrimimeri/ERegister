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

       
        public int? CanYouManage { get; set; }

       
        public string? ActivitiesYourPlan { get; set; }

        
        public int? NeedHelp { get; set; }

 
        public string? SpecificDemand { get; set; }


        public string? GeneralDemands { get; set; }

        
        public string? GeneralDescription { get; set; }

       
        public string? PoliticalSubjects { get; set; }

        
        public string? InitialChance { get; set; }

     
        public string? CurrentVoter { get; set; }


        public string? PreviousVoter { get; set; }

      
        public int? VotersNumber { get; set; }

       
        public string? FacebookLink { get; set; }
        //public int? FamMembersNumber { get; set; }
    }
}
