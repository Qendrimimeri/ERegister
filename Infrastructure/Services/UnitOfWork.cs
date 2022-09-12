using Appliaction.Repository;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;



        public IAccountRepository Account { get; private set; }

        public IAppService AppService { get; private set; }



        public UnitOfWork(ApplicationDbContext dbContext, 
                          ILoggerFactory logger,
                          UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger.CreateLogger("logs");
            Account = new AccountRepository(_dbContext, _logger, _userManager);
            AppService = new AppService(_dbContext, _logger, userManager);
        }



        public async Task Done() => await _dbContext.SaveChangesAsync();

        public async void Dispose() => await _dbContext.DisposeAsync();
    }
}
