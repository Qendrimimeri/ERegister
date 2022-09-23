using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserRepository(ApplicationDbContext db, 
                                         UserManager<ApplicationUser> userManager,
                                         RoleManager<IdentityRole> roleManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<PersonVM>> GetPersonInfoAsync()
        {

            var getAllUsers = await _db.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber = _db.PollRelateds.Where(x => x.UserId == person.Id)
                .FirstOrDefault().FamMembers,
                PreviousVoter = _db.PollRelateds.Where(x => x.UserId == person.Id)
                                                .OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubject.Name,
                CurrentVoter = _db.PollRelateds.Where(x => x.UserId == person.Id)
                               .OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                InitialChances = _db.PollRelateds.Where(x => x.UserId == person.Id)
                                                .FirstOrDefault().SuccessChances,
                ActualChances = _db.PollRelateds.Where(x => x.UserId == person.Id)
                .OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                ActualStatus = person.ActualStatus
            }).ToListAsync();

            var usersInRole = await _userManager.GetUsersInRoleAsync("SimpleRole");

            var result = new List<PersonVM>();
            foreach (var user in getAllUsers)
            {
                foreach (var item in usersInRole)
                {
                    if (user.Id == item.Id)
                        result.Add(user);
                }
            }
            return result;
        }

        //VoterDetails 
        public async Task<List<VoterDetailsVM>> GetVoterInfoAsync()
        {
            var getAllUsers = await _db.Users.Select(person => new VoterDetailsVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                Neigborhood = person.Address.Neighborhood.Name,
                Village = person.Address.Village.Name,
                Block = person.Address.Block.Name,
                HouseNo = person.Address.HouseNo,
                PhoneNumber = person.PhoneNumber,
                Email = person.Email,
                Facebook = person.SocialNetwork,
                FamMembers = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                WorkPlace = person.Work.WorkPlace,
                AdministrativeUnit = person.Work.AdministrativeUnit,
                Duty = person.Work.Duty,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                PoliticalSubjects = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                SuccessChance = person.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().SuccessChances,
            }).ToListAsync();

            var usersInRole = await _userManager.GetUsersInRoleAsync("SimpleRole");

            var result = new List<VoterDetailsVM>();
            foreach (var user in getAllUsers)
            {
                foreach (var item in usersInRole)
                {
                    if (user.Id == item.Id)
                        result.Add(user);
                }
            }
            return result;
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string id)

            => await _userManager.FindByIdAsync(id);

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
            => await _userManager.FindByNameAsync(name);

        public async Task<PersonVM> GetUserByIdAsync(string id)
        {
            var getUser = _db.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                CurrentVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                InitialChances = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().SuccessChances,
                ActualChances = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                ActualStatus = person.ActualStatus
            }).Where(x => x.Id == id).FirstOrDefault();

            return getUser;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token)
            => await _userManager.ConfirmEmailAsync(userIdentity, token);
        public async Task<IdentityResult> AddUserAsync(ApplicationUser user)
        {
            var res = await _userManager.CreateAsync(user);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            var res = await _userManager.UpdateAsync(user);
            await _db.SaveChangesAsync();
            return res;
        }

        public async Task<List<IdentityRole>> GetAllRolesAsync()
        {
            var res = await _roleManager.Roles.ToListAsync();
            var roles = new List<IdentityRole>();
            foreach (var role in res)
                if (role.Name != "SimpleRole")
                    roles.Add(role);

            return roles;
        }
    }

}
