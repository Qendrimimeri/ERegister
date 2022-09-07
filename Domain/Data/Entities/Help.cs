using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class Help
    {
        public int Id { get; set; }
        public bool? CanYouManage { get; set; }
        public string? ActivitiesYouPlan { get; set; }
        public bool? NeedHelp { get; set; }
    }
}
