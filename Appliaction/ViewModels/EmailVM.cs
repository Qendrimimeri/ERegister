﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EmailVM
    {
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }

        public bool IsEmailSent { get; set; } = false;
    }
}
