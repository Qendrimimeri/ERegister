using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LoginVM
    {
        [Required (ErrorMessage = "Ju lutem shkruani email adresë valide!"), DataType(DataType.EmailAddress), Display(Name = "Emaili"),]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ju lutem shkruani fjalëkalimin!"),MaxLength(255), DataType(DataType.Password), Display(Name = "Fjalekalimi")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
