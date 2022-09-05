using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class ActualStatuse
    {
        // Scalar Properties
        public int Id { get; set; }

        // -> perfunduar, ne proces, pa perfunduar
        public string? Description { get; set; }

        // se ni status aktual mun met me kan tek shume usera qata osht list mdfk
        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
