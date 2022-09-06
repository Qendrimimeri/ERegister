using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class GeneralDemandsUser
    {
        public int Id { get; set; }
        public int? GeneralDemandId { get; set; }
        public string? UserId { get; set; }

        public virtual GeneralDemand? GeneralDemand { get; set; }
        public virtual AspNetUser? User { get; set; }
    }
}
