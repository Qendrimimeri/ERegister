﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Emaili")]
        public string Email { get; set; }

        [MaxLength(255)]
        [DataType(DataType.Password)]
        [Display(Name = "Fjalekalimi")]
        public string Password { get; set; }
    }
}
