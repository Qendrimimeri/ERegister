using Appliaction.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IUnitOfWork 
    {
        IAccountRepository Account { get; }

        IAppService AppService { get; }

        Task Done();
    }
}
