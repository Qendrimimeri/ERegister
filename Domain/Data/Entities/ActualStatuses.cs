using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class ActualStatuses
    {
        // Scalar Properties
        public int Id { get; set; }

        // -> perfunduar, ne proces, pa perfunduar
        public string? Description { get; set; }

        // se ni status aktual munet me kan tek shume usera qata osht list mdfk
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
