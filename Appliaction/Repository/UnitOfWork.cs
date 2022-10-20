using Application.Models.Services;
using Application.Repository.IRepository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailService _mail;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IOptionsSnapshot<Encrypt> _encrypt;

        public UnitOfWork(ApplicationDbContext dbContext,
                          ILoggerFactory logger,
                          UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          RoleManager<IdentityRole> roleManager,
                          IMailService mail,
                          IHttpContextAccessor httpContext,
                          IOptionsSnapshot<Encrypt> encrypt)

        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext= httpContext;
            _encrypt = encrypt;
            _mail = mail;
            _roleManager = roleManager;
            _logger = logger.CreateLogger("logs");
            Address = new AddressRepository(_dbContext);
            ApplicationUser = new ApplicationUserRepository(_dbContext, _logger, _mail, _userManager, _signInManager, _roleManager, _httpContext, _encrypt);
            Block = new BlockRepository(_dbContext);
            Help = new HelpRepository(_dbContext);
            KqzRegister = new KqzRegisterRepository(_dbContext);
            Municipality = new MunicipalityRepository(_dbContext);
            Neighborhood=new NeighborhoodRepository(_dbContext);
            PoliticalSubject = new PoliticalSubjectRepository(_dbContext);
            PollCenter = new PollCenterRepository(_dbContext);
            PollRelated = new PollRelatedRepository(_dbContext, ApplicationUser);
            Street = new StreetRepository(_dbContext);
            Village=new VillageRepository(_dbContext);
            Work = new WorkRepository(_dbContext);

        }


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


        public async Task <int> Done() => await _dbContext.SaveChangesAsync();

        public async void Dispose() => await _dbContext.DisposeAsync();

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
