using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class PollRelated
    {
        public int Id { get; set; }
        public int FamMembers { get; set; }
        public DateTime? Date { get; set; }
        public string? VoterId { get; set; }
        public string? PoliticialSubjectNational { get; set; }
        public string? PoliticialSubjectLocal { get; set; }
        public string? SuccessChances { get; set; }
        public string? Reason { get; set; }
        public string? Demand { get; set; }
        public int? HelpId { get; set; }
        public string? Description { get; set; }


        public virtual Help? Help { get; set; }
        public virtual Voter? Voter { get; set; }
    }
}
