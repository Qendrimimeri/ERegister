
using Appliaction.Models;
using Application.Models;
using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Application.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserRepository(ApplicationDbContext db,
                                         UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext,
                                         RoleManager<IdentityRole> roleManager) : base(db)
        {
            _db = db;
            _userManager = userManager;
            _httpContext = httpContext;
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
                PollCenter = person.Address.PollCenter.CenterNumber,
                VotersNumber = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                CurrentVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                InitialChances = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                ActualChances = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,


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
                FacebookLink = person.SocialNetwork,
                WorkPlace = person.Work.WorkPlace,
                AdministrativeUnit = person.Work.AdministrativeUnit,
                Duty = person.Work.Duty,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                InitialChance = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                PreviousVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                CurrentVoter = _db.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,

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

        public async Task<IList<string>> GetRoles(string email)
        {
            var roles = await _userManager.GetRolesAsync(await GetUserByNameAsync(email));

            return roles;
        }

        public async Task<ApplicationUser> FindUserByIdAsync(string id)

            => await _userManager.FindByIdAsync(id);

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
            => await _userManager.FindByEmailAsync(name);

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


        public Claim Profile()
        {
            var user = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            return user;
        }

        public async Task<ProfileVM> GetProfileDetails(string email)
        {

            var getUserDetails = await _db.Users.Select(user => new ProfileVM()
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNo = user.PhoneNumber,
                Email = user.Email,
                Municipality = user.Address.Municipality.Name,
                Village = user.Address.Village.Name,
                PollCenter = user.Address.PollCenter.CenterName,
                ProfileImage=user.ImgPath
                
            }).Where(x => x.Email == email).FirstOrDefaultAsync();
            return getUserDetails;
        }
        public async Task<bool> EditProfileDetails(ProfileVM user, string fullPath)
        {
            var userId = Profile();
            var getUser = await _db.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.ImgPath = fullPath;
            getUser.Email = user.Email;
            getUser.PhoneNumber = user.PhoneNo;
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool>EditUserProfile(ProfileVM user)
        {
            var userId = Profile();
            var getUser = await _db.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.Email = user.Email;
            getUser.PhoneNumber = user.PhoneNo;
            await _db.SaveChangesAsync();
            return true;


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

        public async Task<List<RoleModel>> GetAllRolesAsync()
        {
            var res = await _roleManager.Roles.ToListAsync();
            var roles = new List<RoleModel>();
            foreach (var role in res)
                if (role.Name != "SimpleRole")
                    roles.Add(new RoleModel { Key = role.Name, Value = role.Name });

            return roles;
        }

        public int? GetMunicipalityIdOfUser(string id)
        {
            var res = _db.ApplicationUsers.Where(x => x.Id == id).Select(x => x.Address.MunicipalityId).First();
            return res;
        }
    }

}
