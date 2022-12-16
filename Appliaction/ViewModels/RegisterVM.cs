using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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


        [Required(ErrorMessage = "Ju lutem shkruani emrin dhe mbiemrin!"),
         MinLength(5, ErrorMessage = "Ju lutem plotësoni të dhënat me minimum 5 karaktere!"), 
         MaxLength(255),
         Display(Name = "Emri dhe Mbiemri"), RegularExpression(@"^(?:[a-zA-Z ]|<(?= ))+$", ErrorMessage = "Ju lutem mos shkruni numra!")]
        public string? FullName { get; set; }

        public string? PrefixPhoneNo { get; set; }

        public string? PhoneNumber { get; set; }


        public string? Email { get; set; }

        public string? Facebook { get; set; }
        [Required(ErrorMessage = "Ju lutem zgjedhni komunen!")]
        [ValidateNever]
        public int? Municipality { get; set; }

        [ValidateNever]
        public int? Village { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni lagjen!")]
        [ValidateNever]
        public int? Neigborhood { get; set; }


        [ValidateNever]
        public int? Street { get; set; }

        public int? Block { get; set; }

        public int? HouseNo { get; set; }
        [Required(ErrorMessage = "Ju lutem shkruani vendin e punes!"), 
         RegularExpression(@"^(?:[a-zA-Z ]|<(?= ))+$", ErrorMessage = "Ju lutem mos shkruani numra!")]
        public string? WorkPlace { get; set; }
        [RegularExpression(@"^(?:[a-zA-Z ]|<(?= ))+$", ErrorMessage = "Ju lutem mos shkruani numra!")]
        public string? AdministrativeUnit { get; set; }
        [RegularExpression(@"^(?:[a-zA-Z ]|<(?= ))+$", ErrorMessage = "Ju lutem mos shkruani numra!")]
        public string? Duty { get; set; }


        [Required(ErrorMessage = "Ju lutem shkruani numrin e saktë të anëtarëve!"), 
         Range(1, 99, ErrorMessage = "Ju lutem shkruani një numër real të anëtarëve të familjes!")]
        public int? FamMembers { get; set; }

        [Required]
        public string? SuccessChance { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni partinë politike!")]
        public string? PoliticalSubjectNational { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni partinë politike!")]
        public string? PoliticalSubjectLocal { get; set; }

        [Required(ErrorMessage = "Ju lutem zgjedhni qendrën e votimit!")]
        public string? PollCenter { get; set; }
    }
}
