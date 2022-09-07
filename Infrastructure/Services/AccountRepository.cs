using Application.Repository;
using Domain.Data.Entities;
using ERegister.Data;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        // 
        public AccountRepository(ApplicationDbContext context,
                                SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> GetAppUsers() => throw new NotImplementedException();

        public async Task<bool> LoginAsync(LoginVM login)
        {

            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                    return true;
                return false;
            }
            return false;
        }


    }
}

