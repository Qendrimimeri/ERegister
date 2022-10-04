using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Ju lutem shkruani emrin dhe mbiemrin!"), MinLength(5), MaxLength(255), Display(Name = "Emri dhe Mbiemri")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Numri i telefonit nuk eshte valid!"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresa nuk eshte valide!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Facebook { get; set; }


        [Required( ErrorMessage = "Ju lutem zgjedhni qytetin!")]
        public int? Municipality { get; set; }

        public int? Village { get; set; }
        public int? Neigborhood { get; set; }
        public int? Street { get; set; }
        public int? Block { get; set; }
        public int? HouseNo { get; set; }
        public string WorkPlace { get; set; }
        public string AdministrativeUnit { get; set; }
        public string Duty { get; set; }


        [Required(ErrorMessage ="Ju lutem shkruani numrin e sakte te antareve!"),Range(1,99,ErrorMessage = "Ju lutem shkruani nje numer real te anetareve te familjes!")]
        public int? FamMembers { get; set; }
        
        [Required]
        public string SuccessChance { get; set; }

        [Required(ErrorMessage="Ju lutem zgjedhni partine politike!")]
        public int? PoliticalSubject { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni qendren e votimit!")]
        public string PollCenter { get; set; }
    }
}
