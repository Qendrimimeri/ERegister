using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class PoliticalOfficalVM
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Ju lutem shkruani emrin dhe mbiemrin!"), MinLength(5), MaxLength(255), Display(Name = "Emri dhe Mbiemri")]
        public string? FullName { get; set; }

       [Required(ErrorMessage = "Numri i telefonit nuk eshte valid!"),MinLength(8), MaxLength(13),DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresa nuk eshte valide!"), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Ju lutem zgjedhni qytetin!")]
        public int? Municipality { get; set; }
        public int? Village { get; set; }
        public int? Neigborhood { get; set; }
        public int? Street { get; set; }
        public int? Block { get; set; }
        public int? HouseNo { get; set; }


        [Required(ErrorMessage = "Ju lutem zgjedhni rolin!")]
        public string? Role { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni qendren e votimit!")]
        public string? PollCenter { get; set; }
    }
}
