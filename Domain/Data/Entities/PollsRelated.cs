using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class PollRelated
    {
        public int Id { get; set; }

        public int? FamMember { get; set; }

        public DateTime? Date { get; set; }

        // Navigation properties
        public virtual PoliticalSubject? PoliticalSubjects { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        public virtual SuccessChance? SuccessChances { get; set; }

        public virtual GeneralDemand? GeneralDemand { get; set; }

        public virtual SpecificDemand? MyProperty { get; set; }

        public virtual SpecificReason? SpecificReason { get; set; }

        public virtual Help? Help { get; set; }
    }
}
