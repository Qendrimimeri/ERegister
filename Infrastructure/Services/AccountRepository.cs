using Appliaction.ViewModels;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using ERegister.Application.Repository;
using Infrastructure.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        // 
        public AccountRepository(ApplicationDbContext context,
                                SignInManager<ApplicationUser> signInManager, 
                                UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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
            var getLastRowIdOfAddress =  _context.Addresses.ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            int addressId = getLastRowIdOfAddress.Id + 1;

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


            var getLastRowIdOfWork = _context.Addresses.ToList().OrderByDescending(x => x.Id).FirstOrDefault();
            int workId = getLastRowIdOfWork.Id + 1;
            var work = new Work()
            {
                Id = workId,
                WorkPlace = model.WorkPlace,
                AdministrativeUnitId = model.AdministrativeUnit,
                Duty = model.Duty,
            };


            await _context.Works.Where(x => x.WorkPlace == model.WorkPlace).FirstOrDefaultAsync();
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();

            var simpleUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                WorkId = workId,
                AddressId = addressId,
                ActualStatusId = 1,
            };
            IdentityResult result = await _userManager.CreateAsync(simpleUser, "");
            await _context.SaveChangesAsync();
            return true;
        }

    }
}

