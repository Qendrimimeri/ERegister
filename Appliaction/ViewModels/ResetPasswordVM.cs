using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ResetPasswordVM
    {
        public string? UserId { get; set; }

        public string? Token { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
