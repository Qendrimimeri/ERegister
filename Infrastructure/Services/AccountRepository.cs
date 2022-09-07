using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using ERegister.Application.Repository;
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
    public class AccountRepository : Repository<AspNetUser>, IAccountRepository
    {
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly UserManager<AspNetUser> _userManager;

        // 
        public AccountRepository(ERegisterDBContext context,
                                SignInManager<AspNetUser> signInManager, UserManager<AspNetUser> userManager) : base(context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IEnumerable<AspNetUser> GetAppUsers() => throw new NotImplementedException();

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

