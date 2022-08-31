using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data.Entities
{
    public class ReasonsUsers
    {
        public int Id { get; set; }
        public int? GeneralReasonId { get; set; }
        public int? ApplicationUserId { get; set; }
    }
}
