using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CurrentVoters
    {
        public string? Municipality { get; set; }

        public int NumberOfVotes { get; set; }

        public string? PoliticalSubject { get; set; }
    }
}
