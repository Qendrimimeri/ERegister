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

        [Required(ErrorMessage = "Ju lutem shkruani emrin dhe mbiemrin!"), MinLength(5,ErrorMessage =("Ju lutem plotësoni të dhënat me minimum 5 karaktere!")), MaxLength(255), Display(Name = "Emri dhe Mbiemri"), RegularExpression(@"^(?:[a-zA-Z ]|<(?= ))+$", ErrorMessage = "Ju lutem mos shkruani numra!")]
        public string? FullName { get; set; }

        public string? PrefixPhoneNo { get; set; }

        [Required(ErrorMessage = "Numri i telefonit nuk është valid!"),MinLength(8,ErrorMessage =("Ju lutem shkruani minimumi 8 numra!")), MaxLength(13),DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresa nuk është valide!"), DataType(DataType.EmailAddress,ErrorMessage ="Ju lutem shkruani një email adresë valide!")]
        public string? Email { get; set; }

        public int? Municipality { get; set; }
        
        public int? Village { get; set; }


        [Required(ErrorMessage = "Ju lutem zgjedhni lagjen!")]
        public int? Neigborhood { get; set; }

        public int? Street { get; set; }

        public int? Block { get; set; }

        public int? HouseNo { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni rolin!")]
        public string? Role { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni qendrën e votimit!")]
        public string? PollCenter { get; set; }

        public string? ElectionType { get; set; } 

        public DateTime? ElectionDate { get; set; }

        public int? AAK { get; set; }

        public int? AKR { get; set; }

        public int? LDK { get; set; }

        public int? NISMA { get; set; }

        public int? PDK { get; set; }

        public int? VV { get; set; }

        public int? PartitJoSerbe { get; set; }

        public int? PartitSerbe { get; set; }
    }
}
