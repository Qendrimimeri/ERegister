using Application.Repository;
using Domain.Data.Entities;
using ERegister.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<ApplicationUser> GetAppUsers() => throw new NotImplementedException();
    }
}

