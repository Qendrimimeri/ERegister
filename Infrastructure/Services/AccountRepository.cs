using Appliaction.ViewModels;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using ERegister.Application.Repository;
using Infrastructure.ViewModels;
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

        public AccountRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        // 
        public AccountRepository(ApplicationDbContext context,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                ILogger logger 
                                ) : base(context, logger)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IEnumerable<ApplicationUser> GetAppUsers() => throw new NotImplementedException();

        public async Task<bool> LoginAsync(LoginVM login)
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
            // Let test this shit
            var indexOfSpace = model.FullName.IndexOf(" ");
            string firstName = model.FullName.Substring(0, indexOfSpace);
            string lastName = model.FullName.Substring(indexOfSpace + 1);

            string addressId = new Guid().ToString();

            var address = new Address()
            {
                Id = addressId,
                MunicipalityId = model.Municipality,
                HouseNo = model.HouseNo,
                VillageId = model.Village,
                BlockId = model.StreetBlock,
                StreetId = model.StreetBlock,
                PollCenterId = model.PollCenter,
            };

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();


            string workId = new Guid().ToString();
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

            IdentityResult result = await _userManager.CreateAsync(simpleUser, "");
            await _context.SaveChangesAsync();

            var userId = await _userManager.FindByEmailAsync(model.Email);
            var pollRelated = new PollRelated()
            {
                FamMembers = model.FamMembers,
                Date = DateTime.Now,
                UserId = userId.Id,
                PoliticialSubjectId = 1,
                SuccessChances = model.SuccessChance,
                GeneralReason = "Unset",
                GeneralDemand = "unset",
                SpecificDemand = "unset",
                HelpId = 1
            };

            await _context.PollRelateds.AddAsync(pollRelated);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

