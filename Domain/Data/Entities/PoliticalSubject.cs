using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class PoliticalSubject
    {
        public int Id { get; set; }

        public string? SubjectName { get; set; }


        // Navigation Properties
        public virtual ICollection<PollRelated>? PollRelateds { get; set; }
    }
}
