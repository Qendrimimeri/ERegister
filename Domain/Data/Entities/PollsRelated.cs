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

        public int? PoliticalSubjectId { get; set; }
        public int? ApplicationUserId { get; set; }
        public DateTime? Date { get; set; }
        public int? SuccessId { get; set; }
        public int? WorkId { get; set; }
    }
}
