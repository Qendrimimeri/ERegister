using Domain.Data.Entities;
﻿using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Application.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetUserByNameAsync(string name);
        
        Task<List<PersonVM>> GetPersonInfoAsync();

        Task<PersonVM> GetUserByIdAsync(string id);

        Task<IdentityResult> AddUserAsync(ApplicationUser user);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
    }
}
