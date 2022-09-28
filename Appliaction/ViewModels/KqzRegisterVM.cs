using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [Required(ErrorMessage = "Ju lutem zgjedhni qendren e votimit!")]
        public int PollCenterId { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni daten e zgjedhjeve!")]
        public string DataCreated { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Ju lutem zgjedhni qytetin!")]
        public int MunicipalityId { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni fshatin!")]
        public int VillageId { get; set; }
        public int? NeighborhoodId { get; set; }

        [Required(ErrorMessage = "Ju lutem percaktoni llojin e zgjedhjeve!")]
        public string ElectionType { get; set; }

    }
}
