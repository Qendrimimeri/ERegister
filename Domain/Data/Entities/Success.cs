using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class Success
    {
        public int Id { get; set; }

        public int? StartingSuccessChanceId { get; set; }

        public int? CurrentSuccessChanceId { get; set; }
    }
}
