using Application.Models;
using Application.Repository.IRepository;
using Application.Settings;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Xml.Linq;



namespace Application.Repository
{
#pragma warning disable CS8602
#pragma warning disable CS8604

    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailService _mail;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;



        public ApplicationUserRepository(ApplicationDbContext context,
                                         ILogger logger,
                                         IMailService mail,
                                         UserManager<ApplicationUser> userManager,
                                         SignInManager<ApplicationUser> signInManager,
                                         RoleManager<IdentityRole> roleManager,
                                         IHttpContextAccessor httpContext) : base(context)
        {
            _context = context;
            _logger = logger;
            _mail = mail;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContext = httpContext;
        }

        public async Task<List<PersonVM>> GetPersonInfoAsync()
        {
            var loginUserId = GetLoginUser();
            var userMuni = await GetMunicipalityIdOfUser(loginUserId);
            var isThisUserSuperAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                                 .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), "KryetarIPartise");
            if (isThisUserSuperAdmin)
            {
                var getAllUsers = await _context.Users.Select(person => new PersonVM()
                {
                    Id = person.Id,
                    FullName = person.FullName,
                    PhoneNumber = person.PhoneNumber,
                   // PhoneNumber = EncryptionService.Decrypt(person.PhoneNumber),
                    MunicipalityName = person.Address.Municipality.Name,
                    PollCenter = person.Address.PollCenter.CenterNumber,
                    VotersNumber = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                    PreviousVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                    CurrentVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                    InitialChances = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                    ActualChances = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,


                    ActualStatus = person.ActualStatus
                }).ToListAsync();

                var usersInRole = await _userManager.GetUsersInRoleAsync("SimpleRole");

                var result = new List<PersonVM>();
                foreach (var user in getAllUsers)
                    foreach (var item in usersInRole)
                        if (user.Id == item.Id)
                            result.Add(user);

                return result;
            }
            else
            {
                var getAllUsers = await _context.ApplicationUsers.Include(x => x.Address)
                    .Where(x => x.Address.MunicipalityId == userMuni).Select(person => new PersonVM()
                    {
                        Id = person.Id,
                        FullName = person.FullName,
                        PhoneNumber = person.PhoneNumber,
                        //PhoneNumber = EncryptionService.Decrypt(person.PhoneNumber),

                        MunicipalityName = person.Address.Municipality.Name,
                        PollCenter = person.Address.PollCenter.CenterNumber,
                        VotersNumber = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                        PreviousVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                        CurrentVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                        InitialChances = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                        ActualChances = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,


                        ActualStatus = person.ActualStatus
                    }).ToListAsync();

                var usersInRole = await _userManager.GetUsersInRoleAsync("SimpleRole");

                var result = new List<PersonVM>();
                foreach (var user in getAllUsers)
                    foreach (var item in usersInRole)
                        if (user.Id == item.Id)
                            result.Add(user);

                return result;
            }
        }

        //VoterDetails
        public async Task<VoterDetailsVM> GetVoterInfoAsync(string name)
        {
            var loginUserId = GetLoginUser();
            var userMuni = await GetMunicipalityIdOfUser(loginUserId);
            var isThisUserSuperAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                                 .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), "KryetarIPartise");

            var userFromDb = await _context.ApplicationUsers.Where(x => x.FullName == name).FirstOrDefaultAsync();
            if (userFromDb == null)
                return null;

            var user = await _userManager.IsInRoleAsync(userFromDb, "SimpleRole");

            if (isThisUserSuperAdmin)
            {
                var getUser = await _context.ApplicationUsers.Where(x => x.FullName == name).Select(person => new VoterDetailsVM()
                {

                    Id = person.Id,
                    FullName = person.FullName,
                    Neigborhood = person.Address.Neighborhood.Name,
                    Village = person.Address.Village.Name,
                    Block = person.Address.Block.Name,
                    HouseNo = person.Address.HouseNo,
                    PhoneNumber = person.PhoneNumber,

                    //PhoneNumber = EncryptionService.Decrypt(person.PhoneNumber),
                    Email = person.Email,
                    FacebookLink = person.SocialNetwork,
                    WorkPlace = person.Work.WorkPlace,
                    AdministrativeUnit = person.Work.AdministrativeUnit,
                    Duty = person.Work.Duty,
                    MunicipalityName = person.Address.Municipality.Name,
                    PollCenter = person.Address.PollCenter.CenterNumber,
                    VotersNumber = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                    InitialChance = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                    PreviousVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                    CurrentVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,

                }).FirstOrDefaultAsync();

                if (user)
                    return getUser;
                return null;
            }
            else
            {
                var getUser = await _context.ApplicationUsers.Include(x => x.Address)
                    .Where(x => x.FullName == name && x.Address.MunicipalityId == userMuni).Select(person => new VoterDetailsVM()
                    {
                        Id = person.Id,
                        FullName = person.FullName,
                        Neigborhood = person.Address.Neighborhood.Name,
                        Village = person.Address.Village.Name,
                        Block = person.Address.Block.Name,
                        HouseNo = person.Address.HouseNo,
                        PhoneNumber = person.PhoneNumber,
                        //PhoneNumber = EncryptionService.Decrypt(person.PhoneNumber),

                        Email = person.Email,
                        FacebookLink = person.SocialNetwork,
                        WorkPlace = person.Work.WorkPlace,
                        AdministrativeUnit = person.Work.AdministrativeUnit,
                        Duty = person.Work.Duty,
                        MunicipalityName = person.Address.Municipality.Name,
                        PollCenter = person.Address.PollCenter.CenterName,
                        VotersNumber = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                        InitialChance = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                        PreviousVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                        CurrentVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,

                    }).FirstOrDefaultAsync();

                if (user)
                    return getUser;
                return null;
            }
;
        }

        public async Task<IList<string>> GetRoles(string email)
            => await _userManager.GetRolesAsync(await GetUserByNameAsync(email));


        public async Task<ApplicationUser> FindUserByIdAsync(string id)
            => await _userManager.FindByIdAsync(id);


        public async Task<ApplicationUser> GetUserByNameAsync(string name)
            => await _userManager.FindByEmailAsync(name);

        public async Task<PersonVM> GetUserByIdAsync(string id)
        {
            var getUser = _context.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = person.PhoneNumber,
                //PhoneNumber = EncryptionService.Decrypt(person.PhoneNumber),
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterName,
                VotersNumber = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().PoliticialSubject.Name,
                CurrentVoter = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubject.Name,
                InitialChances = _context.PollRelateds.Where(x => x.UserId == person.Id).FirstOrDefault().SuccessChances,
                ActualChances = _context.PollRelateds.Where(x => x.UserId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
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

            var getUserDetails = await _context.Users.Select(user => new ProfileVM()
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNo = user.PhoneNumber,
                //PhoneNo = EncryptionService.Decrypt(user.PhoneNumber),
                Email = user.Email,
                Municipality = user.Address.Municipality.Name,
                Village = user.Address.Village.Name,
                PollCenter = user.Address.PollCenter.CenterName,
                ProfileImage = user.ImgPath

            }).Where(x => x.Email == email).FirstOrDefaultAsync();
            return getUserDetails;
        }
        public async Task<bool> EditProfileDetails(ProfileVM user, string fullPath)
        {
            var userId = Profile();
            var getUser = await _context.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.ImgPath = fullPath;
            getUser.Email = user.Email;
            getUser.PhoneNumber = user.PhoneNo;

            //getUser.PhoneNumber = EncryptionService.Encrypt(user.PhoneNo);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> EditUserProfile(ProfileVM user)
        {
            var userId = Profile();
            var getUser = await _context.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.Email = user.Email;
            getUser.PhoneNumber = user.PhoneNo;
            //getUser.PhoneNumber = EncryptionService.Encrypt(user.PhoneNo);
            await _context.SaveChangesAsync();
            return true;


        }


        public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token)
            => await _userManager.ConfirmEmailAsync(userIdentity, token);

        public async Task<IdentityResult> AddUserAsync(ApplicationUser user)
        {
            var res = await _userManager.CreateAsync(user);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            var res = await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<List<KeyValueModel>> GetAllRolesAsync()
        {
            var res = await _roleManager.Roles.ToListAsync();
            var roles = new List<KeyValueModel>();
            foreach (var role in res)
                if (role.Name != "SimpleRole")
                    roles.Add(new KeyValueModel { Key = role.Name, Value = role.Name.Replace("I", " i ").ToLower().Capitalize() });

            return roles;
        }

        public async Task<int?> GetMunicipalityIdOfUser(string id)
            => await _context.ApplicationUsers.Where(x => x.Id == id).Select(x => x.Address.MunicipalityId).FirstOrDefaultAsync();

        public async Task<int?> GetVillageIdOfUser(string id)
            => await _context.ApplicationUsers.Where(x => x.Id == id).Select(x => x.Address.VillageId).FirstOrDefaultAsync();

        public async Task<int?> GetNeigborhoodIdOfCityForUser(string id)
            => await _context.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == id && x.Address.Village == null).Select(x => x.Address.NeighborhoodId).FirstOrDefaultAsync();

        public async Task<int?> GetNeigborhoodIdOfVillageForUser(string city, int? fshatiId)
           => await _context.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == city && x.Address.VillageId == fshatiId).Select(x => x.Address.NeighborhoodId).FirstOrDefaultAsync();


        public async Task<bool> LoginAsync(LoginVM login)
        {

            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, login.Password)))
                return false;

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
            if (result.Succeeded)
                return true;
            return false;
        }



        public async Task<bool> RegisterVoterAsync(RegisterVM model)
        {
            string addressId = Guid.NewGuid().ToString();
            var address = new Address()
            {
                Id = addressId,
                MunicipalityId = (model.Municipality == null ? await AdminMunicipalityId() : model.Municipality),
                HouseNo = model.HouseNo,
                VillageId = model.Village,
                BlockId = model.Block,
                StreetId = model.Street,
                NeighborhoodId = model.Neigborhood,
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
                ActualStatus = "Ne Process",
                PhoneNumber = model.PhoneNumber,

                //PhoneNumber = EncryptionService.Encrypt(model.PhoneNumber),

            };

            await _userManager.CreateAsync(simpleUser, "Eregister@!12");
            await _context.SaveChangesAsync();
            await _userManager.AddToRoleAsync(simpleUser, "SimpleRole");

            var userId = await _userManager.FindByEmailAsync(model.Email);
            var pollRelated = new PollRelated()
            {
                FamMembers = (int)model.FamMembers,
                Date = DateTime.Now,
                UserId = userId.Id,
                PoliticialSubjectId = model.PoliticalSubject,
                SuccessChances = model.SuccessChance,
                GeneralReason = "Unset",
                GeneralDemand = "Unset",
                SpecificDemand = "Unset",
                GeneralDescription = "Unset",
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
                MunicipalityId = (model.Municipality == null ? await AdminMunicipalityId() : model.Municipality),
                HouseNo = model.HouseNo,
                VillageId = model.Village,
                BlockId = model.Block,
                StreetId = model.Street,
                NeighborhoodId = model.Neigborhood,
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
                ImgPath = "default.png",
                PhoneNumber = model.PhoneNumber,

                //PhoneNumber = EncryptionService.Encrypt(model.PhoneNumber),
            };

            // Use this for Development env.
            var password = CreateRandomPassword(10);

            var result = await _userManager.CreateAsync(simpleUser, "Admin!23");
            await _context.SaveChangesAsync();


            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(simpleUser);
                var baseUrl = "https://localhost:7278";
                var confimrEmailUrs = $"Account/ConfirmEmail?userId={simpleUser.Id}&token={token}";
                confimrEmailUrs = $"{baseUrl}/{confimrEmailUrs}";

                var domain = model.Email[(model.Email.IndexOf('@') + 1)..].ToLower();

                if (true)
                {

                }
                // Send Email
                var emailReques = new MailRequestModel();

                emailReques.Subject = "PBCA: Konfirmimi i llogaris�.";
                emailReques.Body = $"" +
                    $"Llogaria juaj �sht� regjistruar!" +
                    $"<br>Fjal�kalimi i juaj �sht� <strong>Admin!23</strong>" +
                    $"<br>P�r t� konfirmuar llogarin� tuaj ju lutemi t� <a href={confimrEmailUrs}>klikoni k�tu</a>!" +
                    $"<br><br><strong>E-Register</strong>";

                emailReques.ToEmail = simpleUser.Email;

                await _mail.SendEmailAsync(emailReques);
            }
            await _userManager.AddToRoleAsync(simpleUser, model.Role);

            return true;
        }


        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var baseUrl = "https://localhost:7278";
            var confimrEmailUrs = $"Account/ResetPassword?userId={user.Id}&token={token}";
            confimrEmailUrs = $"{baseUrl}/{confimrEmailUrs}";

            // Send Email
            var emailReques = new MailRequestModel();
            emailReques.Subject = "PBCA: Ndrysho fjal�kalimin.";
            emailReques.Body = $"P�r t� ndryshuar fjal�kalimin tuaj ju lutem <a href={confimrEmailUrs}>Klikoni k�tu</a>!" +
                $" < br >< br >< strong > E - Register </ strong > ";
            emailReques.ToEmail = user.Email;
            await _mail.SendEmailAsync(emailReques);

            return true;
        }


        public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ResetPasswordAsync(ResetPasswordVM model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var res = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            return res;
        }


        public async Task<int> AdminMunicipalityId()
        {
            var userCalim = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = ((int)await _context.Users.Where(x => x.Id == userCalim).Select(x => x.Address.MunicipalityId).FirstOrDefaultAsync());
            return res;
        }


        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public string GetLoginUser()
            => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

#pragma warning restore CS8604 
#pragma warning restore CS8602 

}
