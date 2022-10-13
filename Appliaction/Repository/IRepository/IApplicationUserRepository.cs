using Domain.Data.Entities;
using Application.ViewModels;
using Domain.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
 
using System.Security.Claims;

using Application.Models;


namespace Application.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<IList<string>> GetRoles(string email);

        Task<ApplicationUser> GetUserByNameAsync(string name);
        
        Task<List<PersonVM>> GetPersonInfoAsync();

        Task<List<VoterDetailsVM>> GetVoterInfoAsync();

        Task<int?> GetMunicipalityIdOfUser(string id);

        Task<int?> GetVillageIdOfUser(string id);

        Task<int?> GetNeigborhoodIdOfCityForUser(string id);

        Task<int?> GetNeigborhoodIdOfVillageForUser(string city, int? fshati);

        Task<ApplicationUser> FindUserByIdAsync(string id);

        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token);

        Task<PersonVM> GetUserByIdAsync(string id);

        Task<IdentityResult> AddUserAsync(ApplicationUser user);

        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);

        Claim Profile();

        Task<ProfileVM> GetProfileDetails(string email);

        Task<bool> EditProfileDetails(ProfileVM user, string fullPath);

        Task<bool> EditUserProfile(ProfileVM user);

        Task<List<RoleModel>> GetAllRolesAsync();


    }
}
