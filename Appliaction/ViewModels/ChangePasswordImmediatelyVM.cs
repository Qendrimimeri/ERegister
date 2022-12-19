using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public class ChangePasswordImmediatelyVM
{
    [Required(ErrorMessage = "Ju lutem shkruani fjalëkalimin e ri!")]
    [DataType(DataType.Password)]
    public string? NewPassword { get; set; }

    [Required(ErrorMessage = "Ju lutem shkruani fjalëkalimin e ri!")]
    [DataType(DataType.Password)]
    [Compare("NewPassword", ErrorMessage = "Fjalëkalimet nuk përputhen")]
    public string? ConfirmPassword { get; set; }
}
