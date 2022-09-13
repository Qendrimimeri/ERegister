using Appliaction.Repository;
using Application.Repository;
using Application.Repository.IRepository;
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



        public UnitOfWork(ApplicationDbContext dbContext,
                          ILoggerFactory logger,
                          UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _logger = logger.CreateLogger("logs");
            Account = new AccountRepository(_dbContext, _logger, _userManager);
            AppService = new AppService(_dbContext, _logger, userManager);
            Address = new AddressRepository(_dbContext);
            ApplicationUser = new ApplicationUserRepository(_dbContext);
            Block = new BlockRepository(_dbContext);
            Help = new HelpRepository(_dbContext);
            KqzRegister = new KqzRegisterRepository(_dbContext);
            Municipality = new MunicipalityRepository(_dbContext);
            Neighborhood=new NeighborhoodRepository(_dbContext);
            PoliticalSubject = new PoliticalSubjectRepository(_dbContext);
            PollCenter = new PollCenterRepository(_dbContext);
            PollRelated = new PollRelatedRepository(_dbContext);
            Street = new StreetRepository(_dbContext);
            Village=new VillageRepository(_dbContext);
            Work = new WorkRepository(_dbContext);

        }
        public IAccountRepository Account { get; private set; }

        public IAppService AppService { get; private set; }

        public IAddressRepository Address { get; }
        public IApplicationUserRepository ApplicationUser { get; }
        public IBlockRepository Block { get; }
        public IHelpRepository Help { get; }
        public IKqzRegisterRepository KqzRegister { get; }
        public IMunicipalityRepository Municipality { get; }
        public INeighborhoodRepository Neighborhood { get; }
        public IPoliticalSubjectRepository PoliticalSubject { get; }
        public IPollCenterRepository PollCenter { get; }
        public IPollRelatedRepository PollRelated { get; }
        public IStreetRepository Street { get; }
        public IVillageRepository Village { get; }
        public IWorkRepository Work { get; }


        public async Task Done() => await _dbContext.SaveChangesAsync();

        public async void Dispose() => await _dbContext.DisposeAsync();
    }
}
