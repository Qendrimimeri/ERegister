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
    public interface IAccountRepository : IRepository<AspNetUser>
    {
        IEnumerable<AspNetUser> GetAppUsers();
        Task<bool> LoginAsync(LoginVM login);
    }
}
