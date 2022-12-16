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
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;



namespace Application.Repository;

#pragma warning disable CS8602
#pragma warning disable CS8604


public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{

    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMailService _mail;
    private readonly IHttpContextAccessor _httpContext;
    private readonly Roles _roles;
    private readonly Encrypt _encrypt;
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserRepository(ApplicationDbContext context,
                                     IMailService mail,
                                     UserManager<ApplicationUser> userManager,
                                     SignInManager<ApplicationUser> signInManager,
                                     RoleManager<IdentityRole> roleManager,
                                     IHttpContextAccessor httpContext,
                                     IOptionsSnapshot<Encrypt> encrypt,
                                     IOptionsSnapshot<Roles> roles) : base(context)
    {
        _context = context;
        _mail = mail;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _httpContext = httpContext;
        _roles = roles.Value;
        _encrypt = encrypt.Value;
    }



    public async Task<List<VoterVM>> GetPerformanceLocalVoter()
    {
        EncryptionService encrypt = new(_encrypt);
        var loginUserId = GetLoginUser();
        var userMuni = await GetMunicipalityIdOfUser(loginUserId);
        var userVillage = await GetVillageIdOfUser(loginUserId);

        var appUser = await _context.ApplicationUsers.Where(x => x.Id == loginUserId).FirstOrDefaultAsync();

        var isThisUserSuperAdmin = await _userManager.IsInRoleAsync(appUser, _roles.KryetarIPartise);
        var isThisMunicipalityAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                             .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIKomunes);
        if (isThisUserSuperAdmin)
        {
            var voters = await _context.Voters.Select(person => new VoterVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterNumber,
                VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectLocal,
                CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
                InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                ActualStatus = person.ActualStatus
            }).ToListAsync();

            return voters;
        }
        else if (isThisMunicipalityAdmin)
        {
            var voters = await _context.Voters.Include(x => x.Address)
                .Where(x => x.Address.MunicipalityId == userMuni).Select(person => new VoterVM()
                {
                    Id = person.Id,
                    FullName = person.FullName,
                    PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                    MunicipalityName = person.Address.Municipality.Name,
                    PollCenter = person.Address.PollCenter.CenterNumber,
                    VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                    PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectLocal,
                    CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
                    InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                    ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                    ActualStatus = person.ActualStatus
                }).ToListAsync();

            return voters;
        }
        else
        {
            var voters = await _context.Voters.Include(x => x.Address) //krejt users qe kane id te fshatit
              .Where(x => x.Address.MunicipalityId == userMuni && x.Address.VillageId == userVillage).Select(person => new VoterVM()
              {
                  Id = person.Id,
                  FullName = person.FullName,
                  PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                  Village = person.Address.Village.Name,
                  PollCenter = person.Address.PollCenter.CenterNumber,
                  VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                  PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectLocal,
                  CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
                  InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                  ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                  ActualStatus = person.ActualStatus
              }).ToListAsync();

            return voters;
        }
    }

    public async Task<List<VoterVM>> GetPerformanceNationalVoter()
    {
        EncryptionService encrypt = new(_encrypt);
        var loginUserId = GetLoginUser();
        var userMuni = await GetMunicipalityIdOfUser(loginUserId);
        var userVillage = await GetVillageIdOfUser(loginUserId);

        var appUser = await _context.ApplicationUsers.Where(x => x.Id == loginUserId).FirstOrDefaultAsync();

        var isThisUserSuperAdmin = await _userManager.IsInRoleAsync(appUser, _roles.KryetarIPartise);
        var isThisMunicipalityAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                             .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIKomunes);
        if (isThisUserSuperAdmin)
        {
            var voters = await _context.Voters.Select(person => new VoterVM()
            {
                Id = person.Id,
                FullName = person.FullName,
                PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterNumber,
                VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectNational,
                CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,
                InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                ActualStatus = person.ActualStatus
            }).ToListAsync();

            return voters;
        }
        else if (isThisMunicipalityAdmin)
        {
            var voters = await _context.Voters.Include(x => x.Address)
                .Where(x => x.Address.MunicipalityId == userMuni).Select(person => new VoterVM()
                {
                    Id = person.Id,
                    FullName = person.FullName,
                    PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                    MunicipalityName = person.Address.Municipality.Name,
                    PollCenter = person.Address.PollCenter.CenterNumber,
                    VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                    PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectNational,
                    CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,
                    InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                    ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                    ActualStatus = person.ActualStatus
                }).ToListAsync();

            return voters;
        }
        else
        {
            var voters = await _context.Voters.Include(x => x.Address) //krejt users qe kane id te fshatit
              .Where(x => x.Address.MunicipalityId == userMuni && x.Address.VillageId == userVillage).Select(person => new VoterVM()
              {
                  Id = person.Id,
                  FullName = person.FullName,
                  PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
                  Village = person.Address.Village.Name,
                  PollCenter = person.Address.PollCenter.CenterNumber,
                  VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                  PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().PoliticialSubjectNational,
                  CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,
                  InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).Skip(1).FirstOrDefault().SuccessChances,
                  ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
                  ActualStatus = person.ActualStatus
              }).ToListAsync();

            return voters;
        }
    }


    //VoterDetails
    public async Task<VoterDetailsVM> GetVoterInfoAsync(string name)
    {
        EncryptionService encrypt = new(_encrypt);
        var loginUserId = GetLoginUser();
        var userMuni = await GetMunicipalityIdOfUser(loginUserId);
        var userVillage = await GetVillageIdOfUser(loginUserId);

        var isThisUserMunicipalityAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                             .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIKomunes);

        var isThisUserVillageAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                 .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIFshatit);

        var userFromDb = await _context.Voters.Where(x => x.FullName == name).FirstOrDefaultAsync();
        if (userFromDb == null) return null;


        //if (isThisUserVillageAdmin) return await GetOnlyVillagePerson(userVillage, userMuni, user, name);
        else if (isThisUserMunicipalityAdmin)
        {
            var voters = await _context.Voters.Include(x => x.Address)
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
                    Demands = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Demand,
                    Reason = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Reason,
                    Description = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Description,
                    ActivitiesYourPlan = _context.PollRelateds.Include(x => x.Help).Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Help.ActivitiesYouPlan,
                    MunicipalityName = person.Address.Municipality.Name,
                    PollCenter = person.Address.PollCenter.CenterNumber,
                    VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                    InitialChance = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                    PSLocal = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
                    PSNational = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,

                }).FirstOrDefaultAsync();


            return voters;
        }
        else
        {
            var voters = await _context.Voters.Where(x => x.FullName == name).Select(person => new VoterDetailsVM()
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
                Demands = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Demand,
                Reason = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Reason,
                Description = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Description,
                ActivitiesYourPlan = _context.PollRelateds.Include(x => x.Help).Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().Help.ActivitiesYouPlan,
                MunicipalityName = person.Address.Municipality.Name,
                PollCenter = person.Address.PollCenter.CenterNumber,
                VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
                InitialChance = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
                PSLocal = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
                PSNational = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,
            }).FirstOrDefaultAsync();

            return voters;
        }
;
    }

    public async Task<List<AutoCompleteResult>> AutoCompleteResultAsync(string name)
    {
        EncryptionService encrypt = new(_encrypt);
        var loginUserId = GetLoginUser();
        var userMuni = await GetMunicipalityIdOfUser(loginUserId);
        var userVillage = await GetVillageIdOfUser(loginUserId);

        var isThisUserMunicipalityAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                             .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIKomunes);

        var isThisUserVillageAdmin = await _userManager.IsInRoleAsync((await _context.ApplicationUsers
                 .Where(x => x.Id == loginUserId).FirstOrDefaultAsync()), _roles.KryetarIFshatit);

        var userFromDb = await _context.ApplicationUsers.Where(x => x.FullName == name).FirstOrDefaultAsync();
        if (userFromDb == null)
            return null;


        if (isThisUserMunicipalityAdmin)
        {
            var voters = await _context.ApplicationUsers.Include(x => x.Address)
                .Where(x => x.FullName == name && x.Address.MunicipalityId == userMuni).Select(person => new AutoCompleteResult()
                {
                    Id = person.Id,
                    Name = person.FullName,
                }).ToListAsync();
            return voters;
        }
        else
        {
            var voters = await _context.ApplicationUsers.Where(x => x.FullName == name).Select(person => new AutoCompleteResult()
            {
                Id = person.Id,
                Name = person.FullName,
            }).ToListAsync();

            return voters;
        }
;
    }

    public async Task<IList<string>> GetRoles(string email)
        => await _userManager.GetRolesAsync(await GetUserByNameAsync(email));


    public async Task<ApplicationUser> FindUserByIdAsync(string id)
        => await _userManager.FindByIdAsync(id);


    public async Task<ApplicationUser> GetUserByNameAsync(string name)
        => await _userManager.FindByEmailAsync(name);

    public async Task<VoterVM> GetUserByIdAsync(string id)
    {
        EncryptionService encrypt = new(_encrypt);
        var getUser = _context.Voters.Select(person => new VoterVM()
        {
            Id = person.Id,
            FullName = person.FullName,
            PhoneNumber = encrypt.Decrypt(person.PhoneNumber),
            MunicipalityName = person.Address.Municipality.Name,
            PollCenter = person.Address.PollCenter.CenterName,
            VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
            PreviousVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().PoliticialSubjectNational,
            CurrentVoter = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,
            InitialChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().SuccessChances,
            ActualChances = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().SuccessChances,
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
            Neighborhood = user.Address.Neighborhood.Name

        }).Where(x => x.Email == email)
          .FirstOrDefaultAsync();
        return getUserDetails;
    }

    public async Task<bool> EditProfileDetails(ProfileVM user, string fullPath)
    {
        EncryptionService encrypt = new(_encrypt);
        var userId = Profile();
        var getUser = await _context.Users.Where(x => x.Id == userId.Value)
                                          .FirstOrDefaultAsync();
        getUser.ImgPath = fullPath;
        getUser.PhoneNumber = encrypt.Encrypt(user.PhoneNo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditUserProfile(ProfileVM user)
    {
        EncryptionService encrypt = new(_encrypt);
        var userId = Profile();
        var getUser = await _context.Users.Where(x => x.Id == userId.Value)
                                          .FirstOrDefaultAsync();
        getUser.PhoneNumber = encrypt.Encrypt(user.PhoneNo);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token)
        => await _userManager.ConfirmEmailAsync(userIdentity, token);


    public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
    {
        var res = await _userManager.UpdateAsync(user);
        await _context.SaveChangesAsync();
        return res;
    }

    public async Task<List<KeyValueModel>> GetAllRolesAsync()
    {
        List<KeyValueModel> roles = new ()
        {
            new KeyValueModel { Key = _roles.AnetarIThjeshte, Value = "Anëtar i thjeshtë" },
            new KeyValueModel { Key = _roles.KryetarIFshatit, Value = "Kryetar i nëndegës" },
            new KeyValueModel { Key = _roles.KryetarIKomunes, Value = "Kryetar i degës" },
            new KeyValueModel { Key = _roles.KryetarIPartise, Value = "Kryetar i partisë" }
        };
        var orderedRoles = roles.OrderBy(x => x.Value);
        return roles;
    }

    public async Task<int?> GetMunicipalityIdOfUser(string id)
        => await _context.ApplicationUsers.Where(x => x.Id == id)
                                          .Select(x => x.Address.MunicipalityId)
                                          .FirstOrDefaultAsync();

    public async Task<int?> GetVillageIdOfUser(string id)
        => await _context.ApplicationUsers.Where(x => x.Id == id)
                                          .Select(x => x.Address.VillageId)
                                          .FirstOrDefaultAsync();

    public async Task<int?> GetNeigborhoodIdOfCityForUser(string id)
        => await _context.ApplicationUsers.Include(x => x.Address)
                                          .Where(x => x.Id == id && x.Address.Village == null)
                                          .Select(x => x.Address.NeighborhoodId)
                                          .FirstOrDefaultAsync();

    public async Task<int?> GetNeigborhoodIdOfVillageForUser(string city, int? fshatiId)
       => await _context.ApplicationUsers.Include(x => x.Address)
                                         .Where(x => x.Id == city && x.Address.VillageId == fshatiId)
                                         .Select(x => x.Address.NeighborhoodId)
                                         .FirstOrDefaultAsync();

    public async Task<bool> LoginAsync(LoginVM login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);
        if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, login.Password)))
            return false;
        var res = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
        if (res.Succeeded) return true;
        return false;
    }

    public async Task<bool> IsEmailConfirmed(LoginVM model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || user.EmailConfirmed == true) return true;
        return false;
    }

    public async Task<bool> RegisterVoterAsync(RegisterVM model)
    {
        EncryptionService encrypt = new(_encrypt);

        string email = model.Email.ToLower();
        var userExist = await _context.Voters.Where(x => x.Email == model.Email).FirstOrDefaultAsync();
        if (!(userExist == null)) return false;

        string addressId = Guid.NewGuid().ToString();
        var address = new Address()
        {
            Id = addressId,
            MunicipalityId = model.Municipality ?? await AdminMunicipalityId(),
            HouseNo = model.HouseNo,
            VillageId = model.Village ?? await AdminVillageId(),
            BlockId = model.Block,
            StreetId = model.Street,
            NeighborhoodId = model.Neigborhood ?? await AdminNeigboorhoodId(),
            PollCenterId = int.Parse(model.PollCenter),
        };
        await _context.Addresses.AddAsync(address);

        string workId = Guid.NewGuid().ToString();
        var work = new Work()
        {
            Id = workId,
            WorkPlace = model.WorkPlace,
            AdministrativeUnit = model.AdministrativeUnit,
            Duty = model.Duty,
        };

        await _context.Works.AddAsync(work);
        await _context.SaveChangesAsync();

        var userId = Guid.NewGuid().ToString();
        var voter = new Voter()
        {
            Id = userId,
            FullName = model.FullName.Trim(),
            Email = model.Email,
            WorkId = workId,
            AddressId = addressId,
            SocialNetwork = model.Facebook,
            CreatedAt = DateTime.Now,
            PhoneNumber = encrypt.Encrypt($"{model.PrefixPhoneNo}{model.PhoneNumber}"),
        };

        await _context.Voters.AddAsync(voter);
        await _context.SaveChangesAsync();

        var pollRelated = new PollRelated()
        {
            FamMembers = (int)model.FamMembers,
            Date = DateTime.Now,
            VoterId = userId,
            PoliticialSubjectNational = model.PoliticalSubjectNational,
            PoliticialSubjectLocal = model.PoliticalSubjectLocal,
            SuccessChances = model.SuccessChance,
            HelpId = 1
        };

        await _context.PollRelateds.AddAsync(pollRelated);
        await _context.SaveChangesAsync();
        return true;
    }


    public async Task<Response> AddPoliticalOfficialAsync(PoliticalOfficalVM model)
    {
        var userExist = await _userManager.FindByEmailAsync(model.Email);
        if (!(userExist == null)) return new Response(false, "Ky email Egziston");

        var pollCenterId = _context.PollCenters.Where(x => x.Id == int.Parse(model.PollCenter))
                                               .Select(x => x.Id)
                                               .FirstOrDefault();

        var hasData = await _context.Kqzregisters
                      .Where(x => x.ElectionType == model.ElectionType && x.PollCenterId == pollCenterId)
                      .ToListAsync();

        var hasPollCenterData = await _context.Kqzregisters.Where(x => x.PollCenterId == pollCenterId)
                                                           .Select(x => x.NoOfvotes)
                                                           .ToListAsync();

        // krijo nje list me votat qe vin nga forma
        var noOfVotes = new List<int?>()
        {
            model.VV,
            model.LDK,
            model.PDK,
            model.AAK,
            model.AKR,
            model.NISMA,
            model.PartitSerbe,
            model.PartitJoSerbe
        };


        // bane check nese ki vota per qet poll center ne databaze
        //duke e dit qe jane 8 parti jane 8 rreshata per ni tip te zgjedhjev
        // pra nese jan ma shume se 8 rresha ateher e din qe per qat qender 
        // te votimit jan te regjistruara votat
        if (hasPollCenterData.Count <= 9)
        {
            // kqyr nese votat qe vin prej formes kan vlera apo jan null
            // nese jan null kthe kerkesen mbrapa mos e lejo me vazhdu pa shenu vota
            foreach (var item in noOfVotes)
                if (item == null || model.ElectionDate == null || model.ElectionType == null)
                    return new Response(false, "Ju lutem plotsoni rezultate lidhur me KQZ-n");

            // hasData osht per 1 qender votimi edhe per 1 tip  te zgjedhjev
            // edhe kqyr nese ka te dhana per qat qender t votimit per qat electtion Type.
            if (hasData.Count <= 0)
            {

                // shto ni zyrtar politik pik spari
                var result = await AddPolitical(model);
                if (result.Status)
                {
                    // itero ne listen qe e kem ndertu ma lart edhe shto vota
                    // per at qender te votimit
                    for (int i = 0; i < noOfVotes.Count; i++)
                    {
                        var election = new Kqzregister()
                        {
                            ElectionType = model.ElectionType,
                            PollCenterId = pollCenterId,
                            NoOfvotes = noOfVotes[i],
                            MunicipalityId = model.Municipality ?? await AdminMunicipalityId(),
                            VillageId = model.Village ?? await AdminVillageId(),
                            NeighborhoodId = model.Neigborhood,
                            PoliticialSubject = " ",
                            DataCreated = model.ElectionDate.ToString(),
                        };
                        await _context.Kqzregisters.AddAsync(election);
                    }

                    // nese osht 0 ose ma e vogel eteher e dim qe rrezultatet nuk jan ruajtur kshtu
                    // qe mos e ruaj as zyrtarin poltik
                    if (await _context.SaveChangesAsync() <= 0)
                    {
                        _context.ApplicationUsers.Remove(await _context.ApplicationUsers.Where(x => x.Email == model.Email).FirstOrDefaultAsync());
                        await _context.SaveChangesAsync();
                        return new Response(false, "Diqka ka shkuar keq");
                    }
                }
                return result;
            }
            else
            {
                // ky else osht nese ka vota per qat qener te votimit edhe doni me i bo update votat perkatse
                // psh Id=2 ElectionType="Zgjedhje Nacionale" ateher me ket else i bon update vetem nr. e votav
                // edhe e regjistron zyrtarin perkats
                var result = await AddPolitical(model);
                for (int i = 0; i < hasData.Count; i++)
                    hasData[i].NoOfvotes = noOfVotes[i];

                await _context.SaveChangesAsync();
            }
            return new Response(true, "U regjistrua me sukses");
        }
        else
        {
            // ky else esht nese nuk  deshiron te shtoni  vota per at qender te votimit
            // po deshironi vetem te shtoni  nje zyrtar
            var res = await AddPolitical(model);
            if ( model.ElectionDate != null && model.ElectionType != null )
            {
                // po ne qoft se ju plotsoni tabelen qe osht opsionale
                // ateher votat to te behen update
                for (int i = 0; i < hasData.Count; i++)
                {
                    hasData[i].NoOfvotes = noOfVotes[i];
                    hasData[i].DataCreated = model.ElectionDate.ToString();
                }
                await _context.SaveChangesAsync();
            }
        }
        return new Response(true, "U regjistrua me sukses");
    }


    public async Task<bool> ForgotPasswordAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        string domain = "https://vota.live";
        var resetPasswordUrl = $"{domain}/Account/ResetPassword?userId={user.Id}&token={token}";

        // Send Email
        var emailReques = new MailRequestModel();
        emailReques.Subject = "e-Vota: Ndrysho fjalëkalimin.";
        emailReques.Body = $"Përshëndetje!" +
                           $"<br><br>Për të krijuar fjalëkalim të ri ju lutem <a href={resetPasswordUrl}>klikoni këtu</a>!" +
                           $"<br><br>Suksese!" +
                           $"<br>Personeli i<strong> e-Vota </strong> ";
        emailReques.ToEmail = user.Email;
        await _mail.SendEmailAsync(emailReques);

        return true;
    }


    public async Task<Microsoft.AspNetCore.Identity.IdentityResult> ResetPasswordAsync(ResetPasswordVM model)
    {
        var res = await _userManager.ResetPasswordAsync((await _userManager.FindByIdAsync(model.UserId)), model.Token, model.NewPassword);
        return res;
    }



    public async Task<int> AdminMunicipalityId()
    {
        var res = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var r = ((int)await _context.ApplicationUsers.Where(x => x.Id == res).Include(x => x.Address)
                          .Select(x => x.Address.MunicipalityId)
                          .FirstOrDefaultAsync());
        return r;
    }


    public async Task<int?> AdminVillageId()
    {
        var res = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var r = await _context.ApplicationUsers.Where(x => x.Id == res).Include(x => x.Address)
                          .Select(x => x.Address.VillageId)
                          .FirstOrDefaultAsync();
        return r;
    }

    public async Task<int> AdminNeigboorhoodId()
    {
        var res = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        var r = (int)await _context.ApplicationUsers.Where(x => x.Id == res.Value).Include(x => x.Address)
                                  .Select(x => x.Address.NeighborhoodId)
                                  .FirstOrDefaultAsync();
        return r;
    }


    private static string CreateRandomPassword(int passwordLength)
    {
        string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$";
        char[] chars = new char[passwordLength];
        Random rd = new();

        for (int i = 0; i < passwordLength; i++)
            chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];

        return new string(chars);
    }

    public string GetLoginUser()
        => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public bool GetEmail(string email)
    {
        var res = _context.ApplicationUsers.Where(x => x.Email == email)
                                           .Select(x => x.Email)
                                           .FirstOrDefault();
        if (res != null)
            return true;
        return false;

    }

    public async Task<bool> CheckUser(string email, string password) =>
        await _userManager.CheckPasswordAsync(await _userManager.FindByEmailAsync(email), password);


    public async Task<bool> IsInSimpleRole(string email) =>
        await _userManager.IsInRoleAsync((await _userManager.FindByEmailAsync(email)), _roles.AnetarIThjeshte);

    public async Task<bool> IsInRoleKryetarIFshatit(string id) =>
        await _userManager.IsInRoleAsync((await _userManager.FindByIdAsync(id)), _roles.KryetarIFshatit);

    public async Task<bool> IsInRoleKryetarIFshatitWithEmail(string email) =>
        await _userManager.IsInRoleAsync((await _userManager.FindByEmailAsync(email)), _roles.KryetarIFshatit);

    public async Task<bool> IsInRoleAnetarIThjeshtWithEmail(string email) =>
        await _userManager.IsInRoleAsync((await _userManager.FindByEmailAsync(email)), _roles.AnetarIThjeshte);


    public async Task<IdentityResult> ChangePassword(string password)
    {
        var user = await _userManager.FindByIdAsync(GetLoginUser());
        var result = await _userManager.ResetPasswordAsync(user, (await _userManager.GeneratePasswordResetTokenAsync(user)), password);
        if (result.Succeeded)
        {
            user.HasPasswordChange = 1;
            _context.Update(user);
            _context.SaveChanges();
        }
        return result;
    }

    public async Task<bool?> HasPasswordChange()
    {
        var user = await _userManager.FindByIdAsync(GetLoginUser());
        var res = user.HasPasswordChange;
        if (res == null || res == 0) return false;
        return true;
    }

    public async Task<List<SuggetVoters>> GetVotersSuggest(string suggest, int muniId) =>
        await _context.Voters.Include(x => x.Address).Where(x => x.FullName.Contains(suggest) && x.Address.MunicipalityId == muniId).Select( x => new SuggetVoters()
        {
            Label = x.FullName,
            Val = x.Id
        }).ToListAsync();


    #region Add Political

    private async Task<Response> AddPolitical(PoliticalOfficalVM model)
    {
        string email = model.Email.ToLower();
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



        var simpleUser = new ApplicationUser()
        {
            FullName = model.FullName.Trim(),
            Email = email,
            UserName = email,
            CreatedAt = DateTime.Now,
            AddressId = addressId,
            ImgPath = "default.png",
            PhoneNumber = encrypt.Encrypt($"{model.PrefixPhoneNo}{model.PhoneNumber}"),
        };

        // Use this for Development env.
        var password = CreateRandomPassword(10);

        var result = await _userManager.CreateAsync(simpleUser, password);
        await _context.SaveChangesAsync();

        if (result.Succeeded)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(simpleUser);
            string domainApp = "https://vota.live";

            var confimrEmailUrs = $"{domainApp}/Account/ConfirmEmail?userId={simpleUser.Id}&token={token}";

            var domain = model.Email[(model.Email.IndexOf('@') + 1)..].ToLower();
            string domainName = "https://vota.live";
            var emailReques = new MailRequestModel
            {
                Subject = "E-Vota: Konfirmimi i llogarisë.",
                Body =
                "Përshëndetje!" +
                $"<br><br>Urime! Sapo është krijuar llogaria juaj në platformën e-Vota" +
                $"<br>Klikoni <a href={confimrEmailUrs}>këtu</a> për të verifikuar adresen tuaj elektronike, ju lutem." +
                $"<br>Fjalëkalimi juaj është <strong>{password}</strong> ju lusim ta ndërroni fjalëkalimin tuaj në platformën e-Vota <br> Fjalëkalimin mund të ndërroni duke klikuar mbi Profile => Ndrysho fjalëkalimin" +
                $"<br>Suksese në punën tuaj, i'u priftë e mbara!" +
                $"<br><br>Me respekt," +
                $"<br>Personeli i <a href={domainName}>Vota.live</a>",
                ToEmail = simpleUser.Email
            };

            await _mail.SendEmailAsync(emailReques);
            await _userManager.AddToRoleAsync(simpleUser, model.Role);
        }
        else if (!result.Succeeded)
        {
            _context.Addresses.Remove(await _context.Addresses.Where(x => x.Id == addressId).FirstOrDefaultAsync());
            _context.Works.Remove(await _context.Works.Where(x => x.Id == workId).FirstOrDefaultAsync());
            await _context.SaveChangesAsync();
            return new Response(false, "Nuk u regjistrua me sukses");
        }
        return new Response(true, "U regjistrua me sukses");
    }

    #endregion


    #region

    private async Task<VoterDetailsVM> GetOnlyVillagePerson(int? villageId, int? muniId, bool isUser, string name)
    {
        EncryptionService encrypt = new(_encrypt);
        var getUser = await _context.Voters.Include(x => x.Address)
        .Where(x => x.FullName == name && x.Address.MunicipalityId == muniId && x.Address.VillageId == villageId)
        .Select(person => new VoterDetailsVM()
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
            VotersNumber = _context.PollRelateds.Where(x => x.VoterId == person.Id).FirstOrDefault().FamMembers,
            InitialChance = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderBy(x => x.Date).FirstOrDefault().SuccessChances,
            PSLocal = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectLocal,
            PSNational = _context.PollRelateds.Where(x => x.VoterId == person.Id).OrderByDescending(x => x.Date).FirstOrDefault().PoliticialSubjectNational,

        }).FirstOrDefaultAsync();

        if (isUser)
            return getUser;
        return null;
    }
    #endregion
}



#pragma warning restore CS8604
#pragma warning restore CS8602
