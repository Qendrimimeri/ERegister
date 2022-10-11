using Application.ViewModels;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using Application.Models;
using System.Security.Policy;
using Appliaction.Repository;
using Microsoft.AspNetCore.Http;

using System.Net.Http;
using System.Security.Claims;
using Appliaction.Models;

namespace Infrastructure.Services
{
#pragma warning disable CS8602 

    public class AccountRepository : Repository<ApplicationUser>, IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailService _mail;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AccountRepository(ApplicationDbContext context,
                                  ILogger logger,
                                  UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager,
                                  IMailService mail,
                                  IHttpContextAccessor httpContext)
                                : base(context, logger, userManager, signInManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _mail = mail;
            _httpContext = httpContext;
        }


        async Task<bool> IAccountRepository.LoginAsync(LoginVM login)
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
              
                emailReques.Subject = "PBCA: Konfirmimi i llogarisë.";
                emailReques.Body = $"" +
                    $"Llogaria juaj është regjistruar!" +
                    $"<br>Fjalëkalimi i juaj është <strong>Admin!23</strong>" +
                    $"<br>Për të konfirmuar llogarinë tuaj ju lutemi të <a href={confimrEmailUrs}>klikoni këtu</a>!" +
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
            emailReques.Subject = "PBCA: Ndrysho fjalëkalimin.";
            emailReques.Body = $"Për të ndryshuar fjalëkalimin tuaj ju lutem <a href={confimrEmailUrs}>Klikoni këtu</a>!" +
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
            var res =  ((int)await  _context.Users.Where(x => x.Id == userCalim).Select(x => x.Address.MunicipalityId).FirstOrDefaultAsync());
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
    }
#pragma warning restore CS8602

}

