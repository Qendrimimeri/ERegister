using Application.ViewModels;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AccountRepository(ApplicationDbContext context,
                                  ILogger logger,
                                  UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
                                : base(context, logger, userManager, signInManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
        }


        async Task<bool> IAccountRepository.LoginAsync(LoginVM login)
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

        public async Task<bool> RegisterVoterAsync(RegisterVM model)
        {
            string addressId = Guid.NewGuid().ToString();
            var address = new Address()
            {
                Id = addressId,
                MunicipalityId = model.Municipality,
                HouseNo = model.HouseNo,
                VillageId = model.Village,
                BlockId = model.Block,
                StreetId = model.Street,
                PollCenterId = int.Parse(model.PollCenter),
            };

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            string workId = Guid.NewGuid().ToString();
            var work = new Work()
            {
                Id = workId,
                WorkPlace = model.WorkPlace,
                AdministrativeUnit = model.AdministrativeUnit,
                Duty = model.Duty,
            };


            await _context.Works.Where(x => x.WorkPlace == model.WorkPlace).FirstOrDefaultAsync();
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();


            var simpleUser = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                WorkId = workId,
                AddressId = addressId,
                ActualStatus = "unset",
            };

            IdentityResult result = await _userManager.CreateAsync(simpleUser, "Eregister@!12");
            await _context.SaveChangesAsync();


            var userId = await _userManager.FindByEmailAsync(model.Email);
            var pollRelated = new PollRelated()
            {
                FamMembers = 2,
                Date = DateTime.Now,
                UserId = userId.Id,
                PoliticialSubjectId = 1,
                SuccessChances = "",
                GeneralReason = "Unset",
                GeneralDemand = "unset",
                SpecificDemand = "unset",
                HelpId = 1
            };

            await _context.PollRelateds.AddAsync(pollRelated);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddPoliticalOfficialAsync(PoliticalOfficalVM model)
        {
            string addressId = Guid.NewGuid().ToString();
            var address = new Address()
            {
                Id = addressId,
                MunicipalityId = model.Municipality,
                HouseNo = model.HouseNo,
                VillageId = model.Village,
                BlockId = model.Block,
                StreetId = model.Street,
                PollCenterId = int.Parse(model.PollCenter),
            };

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            string workId = Guid.NewGuid().ToString();
            var work = new Work()
            {
                Id = workId,
                WorkPlace = "VV",
                AdministrativeUnit = "Sherbimi Publik",
                Duty = model.Role,
            };


            await _context.Works.Where(x => x.WorkPlace == "").FirstOrDefaultAsync();
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();


            var simpleUser = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Email,
                UserName = model.Email,
                WorkId = workId,
                AddressId = addressId,
                ActualStatus = "unset",
            };

            var result = await _userManager.CreateAsync(simpleUser, "Admin!23");
            await _context.SaveChangesAsync();
            await _userManager.AddToRoleAsync(simpleUser, "MunicipalityAdmin");

            return true;
        }
    }
}

