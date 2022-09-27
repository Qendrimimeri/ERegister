using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class GeneralDemandVM
    {
        public int Id { get; set; }
        public int? FamMembers { get; set; }
        public DateTime? Date { get; set; }
        public string? UserId { get; set; }
        public int? PoliticialSubjectId { get; set; }
        public string? SuccessChances { get; set; }
        public string? GeneralReason { get; set; }
        public string? GeneralDemand { get; set; }
        public string? SpecificReason { get; set; }
        public string? SpecificDemand { get; set; }
        public int? HelpId { get; set; }
        public string? GeneralDescription { get; set; }
    }
}
