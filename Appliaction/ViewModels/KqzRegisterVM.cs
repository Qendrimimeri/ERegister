using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class KqzRegisterVM
    {
        public int Id { get; set; }
        public int? PoliticialSubjectId { get; set; }
        public int? NoOfvotes { get; set; }
        public int? PollCenterId { get; set; }
        public string? DataCreated { get; set; }
        public int? MunicipalityId { get; set; }
        public int? VillageId { get; set; }
        public int? NeighborhoodId { get; set; }
        public string? ElectionType { get; set; }
    }
}
