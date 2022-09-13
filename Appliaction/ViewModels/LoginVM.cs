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
        [Required, EmailAddress]
        public string Email { get; set; }
        //[Required, MinLength(8, ErrorMessage = "Password should be more than 8 caharacters")]
        public string Password { get; set; }
    }
}
