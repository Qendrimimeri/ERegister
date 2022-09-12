using Application.Repository;
using Domain.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public IAccountRepository Account { get; private set; }


        public UnitOfWork(ApplicationDbContext dbContext, 
                          ILoggerFactory logger)
        {
            _dbContext = dbContext;
            _logger = logger.CreateLogger("logs");
            Account = new AccountRepository(_dbContext, _logger);
        }

        public IAccountRepository AccountRepository => throw new NotImplementedException();

        public async Task Done() => await _dbContext.SaveChangesAsync();

        public async void Dispose() => await _dbContext.DisposeAsync();
    }
}
