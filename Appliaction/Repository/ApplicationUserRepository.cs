using Application.Models;
using Application.Models.Services;
using Application.Repository.IRepository;
using Application.Settings;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;



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
        private readonly Encrypt _encrypt;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(ApplicationDbContext context,
                                         IMailService mail,
                                         UserManager<ApplicationUser> userManager,
                                         SignInManager<ApplicationUser> signInManager,
                                         RoleManager<IdentityRole> roleManager,
                                         IHttpContextAccessor httpContext,
                                         IOptionsSnapshot<Encrypt> encrypt) : base(context)
        {
            _context = context;
            _mail = mail;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _httpContext = httpContext;
            _encrypt = encrypt.Value;
        }

        public async Task<List<PersonVM>> GetPersonInfoAsync()
        {
            EncryptionService encrypt = new (_encrypt);
            var loginUserId = GetLoginUser();
            var userMuni = await GetMunicipalityIdOfUser(loginUserId);
            var userVillage = await GetVillageIdOfUser(loginUserId);

            var appUser = await _context.ApplicationUsers.Where(x => x.Id == loginUserId).FirstOrDefaultAsync();

            var isThisUserSuperAdmin = await _userManager.IsInRoleAsync(appUser, "KryetarIPartise");
            var isThisMunicipalityAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                                 .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), "KryetarIKomunes");
            if (isThisUserSuperAdmin)
            {
                var getAllUsers = await _context.Users.Select(person => new PersonVM()
                {
                    Id = person.Id,
                    FullName = person.FullName,
                    PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
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

            else if (isThisMunicipalityAdmin)
            {
                var getAllUsers = await _context.ApplicationUsers.Include(x => x.Address)
                    .Where(x => x.Address.MunicipalityId == userMuni).Select(person => new PersonVM()
                    {
                        Id = person.Id,
                        FullName = person.FullName,
                        PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
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
                  .Where(x => x.Address.VillageId == userVillage).Select(person => new PersonVM()
                  {
                      Id = person.Id,
                      FullName = person.FullName,
                      PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                      Village = person.Address.Village.Name,
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
            EncryptionService encrypt = new(_encrypt);
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

                    PhoneNumber = encrypt.Decrypt(person.PhoneNumber),

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
                        PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
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
            EncryptionService encrypt = new(_encrypt);
            var getUser = _context.Users.Select(person => new PersonVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
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


        public Claim Profile() =>
            _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);

        public async Task<ProfileVM> GetProfileDetails(string email)
        {
            EncryptionService encrypt = new(_encrypt);
            var getUserDetails = await _context.Users.Select(user => new ProfileVM()
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNo = encrypt.Decrypt(user.PhoneNumber),
                Email = user.Email,
                Municipality = user.Address.Municipality.Name,
                Village = user.Address.Village.Name,
                PollCenter = user.Address.PollCenter.CenterNumber,
                ProfileImage = user.ImgPath,
                Neighborhood=user.Address.Neighborhood.Name

            }).Where(x => x.Email == email).FirstOrDefaultAsync();
            return getUserDetails;
        }

        public async Task<bool> EditProfileDetails(ProfileVM user, string fullPath)
        {
            EncryptionService encrypt = new(_encrypt);
            var userId = Profile();
            var getUser = await _context.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.ImgPath = fullPath;
            getUser.Email = user.Email;
            getUser.NormalizedEmail = user.Email.ToUpper();


            getUser.PhoneNumber = encrypt.Encrypt(user.PhoneNo);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditUserProfile(ProfileVM user)
        {
            EncryptionService encrypt = new(_encrypt);
            var userId = Profile();
            var getUser = await _context.Users.Where(x => x.Id == userId.Value).FirstOrDefaultAsync();
            getUser.Email = user.Email;
            getUser.NormalizedEmail = user.Email.ToUpper();
           

            getUser.PhoneNumber = user.PhoneNo;

            getUser.PhoneNumber = encrypt.Encrypt(user.PhoneNo);

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
            EncryptionService encrypt = new (_encrypt);
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
                SocialNetwork = model.Facebook,
                PhoneNumber = encrypt.Encrypt($"{model.PrefixPhoneNo}{model.PhoneNumber}"),
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
            EncryptionService encrypt = new(_encrypt);

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

            string email = model.Email.ToLower();
            var simpleUser = new ApplicationUser()
            {
                FullName = email,
                Email = email,
                UserName = email,
                WorkId = workId,
                AddressId = addressId,
                ActualStatus = "unset",
                ImgPath = "default.png",

                PhoneNumber = encrypt.Encrypt($"{model.PrefixPhoneNo}{model.PhoneNumber}"),
            };

            // Use this for Development env.
            var password = CreateRandomPassword(8);

            var result = await _userManager.CreateAsync(simpleUser, password);
            await _context.SaveChangesAsync();


            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(simpleUser);
                string domainApp = "https://vota.live";

                var confimrEmailUrs = $"{domainApp}/Account/ConfirmEmail?userId={simpleUser.Id}&token={token}";

                var domain = model.Email[(model.Email.IndexOf('@') + 1)..].ToLower();

                if (true)
                {

                }
                // Send Email
                var emailReques = new MailRequestModel();

                emailReques.Subject = "E-Vota: Konfirmimi i llogarisë.";
                emailReques.Body = $"" +
                    $"Llogaria juaj është regjistruar!" +
                    $"<br>Fjalëkalimi i juaj është <strong>{password}</strong>" +
                    $"<br>Për të konfirmuar llogarinë tuaj ju lutemi të <a href={confimrEmailUrs}>klikoni këtu</a>!" +
                    $"<br><br><strong>E-Vota</strong>";

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
            string domain = "https://vota.live";
            var confimrEmailUrs = $"{domain}/Account/ResetPassword?userId={user.Id}&token={token}";

            // Send Email
            var emailReques = new MailRequestModel();
            emailReques.Subject = "E-Vota: Ndrysho fjalëkalimin.";
            emailReques.Body = $"Për të ndryshuar fjalëkalimin tuaj ju lutem <a href={confimrEmailUrs}>Klikoni këtu</a>!" +
                               $"<br><br><strong> E - Vota </strong> ";
            emailReques.ToEmail = user.Email;
            await _mail.SendEmailAsync(emailReques);

            return true;
        }


        public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ResetPasswordAsync(ResetPasswordVM model) =>
            await _userManager.ResetPasswordAsync((await _userManager.FindByIdAsync(model.UserId)), model.Token, model.NewPassword);


        public async Task<int> AdminMunicipalityId() =>
            ((int)await _context.Users.Where(x => x.Id == (_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)))
                                      .Select(x => x.Address.MunicipalityId).FirstOrDefaultAsync());


        private static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

            return new string(chars);
        }

        public string GetLoginUser()
            => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public bool GetEmail(string email)
        {
            var res = _context.ApplicationUsers.Where(x => x.Email == email).Select(x => x.Email).FirstOrDefault();
            if (res != null)
                return true;
            return false;

        }

        public async Task<bool> CheckUser(string email, string password) =>
            await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(email), password);


        public async Task<bool> IsInSimpleRole(string email) =>
            await _userManager.IsInRoleAsync((await _userManager.FindByEmailAsync(email)), "AnetarIThjeshte");
    }

#pragma warning restore CS8604 
#pragma warning restore CS8602 
}