using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class PollRelated
    {
        public int Id { get; set; }
        public int? FamMembers { get; set; }
        public DateTime? Date { get; set; }
        public string? UserId { get; set; }
        public int? PoliticalSubjectId { get; set; }
        public int? SuccessChancesId { get; set; }
        public int? GeneralReasonId { get; set; }
        public int? SpecificReasonId { get; set; }
        public int? SpecificDemandId { get; set; }

        public virtual GeneralReason? GeneralReason { get; set; }
        public virtual PoliticalSubject? PoliticalSubject { get; set; }
        public virtual SpecificDemand? SpecificDemand { get; set; }
        public virtual SpecificReason? SpecificReason { get; set; }
        public virtual SuccessChance? SuccessChances { get; set; }
        public virtual AspNetUser? User { get; set; }
    }
}
