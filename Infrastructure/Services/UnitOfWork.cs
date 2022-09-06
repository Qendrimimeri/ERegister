using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository => throw new NotImplementedException();

        public void Dispose() => throw new NotImplementedException();

        public int Done() => throw new NotImplementedException();
    }
}
