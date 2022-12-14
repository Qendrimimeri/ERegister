using Domain.Data.Entities;
using ERegister.Application.Repository;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetAppUsers();
        Task<bool> LoginAsync(LoginVM login);
    }
}
