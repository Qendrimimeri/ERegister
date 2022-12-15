using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Data.Entities
{
    public partial class ApplicationUser : IdentityUser
    {

        public string? FullName { get; set; }
        public string? SocialNetwork { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AddressId { get; set; } = null!;
        public string? ImgPath { get; set; }
        public int? HasPasswordChange { get; set; }


        public virtual Address Address { get; set; } = null!;
    }
}
