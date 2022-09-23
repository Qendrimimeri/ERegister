using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PollCenterVM
    {

        public int Id { get; set; }
        public string? CenterNumber { get; set; }
        public string? CenterName { get; set; }
        public int? MunicipalitydId { get; set; }
    }
}
