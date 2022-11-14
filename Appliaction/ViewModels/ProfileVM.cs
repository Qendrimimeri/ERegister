using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProfileVM
    {
        public string? Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Municipality { get; set; }
        public string? Village { get; set; }
        public string? Role { get; set; }
        public string? PollCenter { get; set; }
        public string ? Neighborhood { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

        public string? ProfileImage { get; set; }
    }
}
