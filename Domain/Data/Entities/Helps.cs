using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Helps
    {
        public int Id { get; set; }

        public bool CanYouManage { get; set; }

        public string? ActivitiesYouPlan { get; set; }

        public bool NeedHelp { get; set; }



    }
}
