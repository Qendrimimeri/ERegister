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

        /// <summary>
        /// Gets application user's role with the specified email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A list of strings containing roles name of ApplicationUsers</returns>
        Task<IList<string>> GetRoles(string email);

        /// <summary>
        /// Gets an application user based on specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>ApplicationUser</returns>
        Task<ApplicationUser> GetUserByNameAsync(string name);
        
        /// <summary>
        /// Gets information of voters
        /// </summary>
        /// <returns>A list of information for voters of type PersonVM</returns>
        Task<List<VoterVM>> GetPersonInfoAsync();


        /// <summary>
        /// Gets information of voters from VoterDetailsVM based on specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Details about specific user of type VoterDetailsVM</returns>
        Task<VoterDetailsVM> GetVoterInfoAsync(string name);

        /// <summary>
        /// Gets the MunicipalityId of a specific ApplicationUser based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The MunicipalityId of ApplicationUser</returns>
        Task<int?> GetMunicipalityIdOfUser(string id);

        /// <summary>
        ///  Gets the VillageId of a specific ApplicationUser based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The VillageId of specified user type int</returns>
        Task<int?> GetVillageIdOfUser(string id);

        /// <summary>
        /// Gets the NeighborhoodId of a specific municipality of user based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The NeighborhoodId of specified user municipality  of type int</returns>
        Task<int?> GetNeigborhoodIdOfCityForUser(string id);

        /// <summary>
        /// Gets the NeighborhoodId  of a specific users village based on the name of 
        /// municipality, and the id of village
        /// </summary>
        /// <param name="city"></param>
        /// <param name="fshati"></param>
        /// <returns>NeighborhoodId of the users village  of type  int</returns>
        Task<int?> GetNeigborhoodIdOfVillageForUser(string city, int? fshati);

        /// <summary>
        /// Gets specific Application User based on their Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Application User</returns>
        Task<ApplicationUser> FindUserByIdAsync(string id);

        /// <summary>
        /// Confirms email for a specified application user based on 
        /// the user and their token 
        /// </summary>
        /// <param name="userIdentity"></param>
        /// <param name="token"></param>
        /// <returns>Identity Result </returns>
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token);

        /// <summary>
        /// Gets user of type PersonVm based on their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User of type PersonVM</returns>
        Task<VoterVM> GetUserByIdAsync(string id);


        /// <summary>
        /// Updates specific user based on specified model of ApplicationUser
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Identity Result</returns>
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);

        /// <summary>
        /// Gets Profile details of a specific user based on Claims
        /// </summary>
        /// <returns>User</returns>
        Claim Profile();

        /// <summary>
        /// Get profile details of a specific user based on their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User of type ProfileVM</returns>
        Task<ProfileVM> GetProfileDetails(string email);

        /// <summary>
        /// Edits user email, profile image and phone number
        /// based on specific user and their image path
        /// </summary>
        /// <param name="user"></param>
        /// <param name="fullPath"></param>
        /// <returns>Bool Result</returns>
        Task<bool> EditProfileDetails(ProfileVM user, string fullPath);
        /// <summary>
        /// Edits user email and phone number
        /// based on specific user of type ProfileVM
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Bool Result</returns>
        Task<bool> EditUserProfile(ProfileVM user);

        /// <summary>
        /// Gets all user roles except for the 'Simple Role'
        /// </summary>
        /// <returns>A generic type of collection of user roles</returns>
        Task<List<KeyValueModel>> GetAllRolesAsync();

        /// <summary>
        /// Checks login information for specficid user based on 
        /// the LoginVm 
        /// </summary>
        /// <param name="login"></param>
        /// <returns>True or False/returns>
        Task<bool> LoginAsync(LoginVM login);

        /// <summary>
        /// Registers a new voter based on information required on specified
        /// RegisterVM model
        /// </summary>
        /// <param name="register"></param>
        /// <returns>True or False</returns>
        Task<bool> RegisterVoterAsync(RegisterVM register);


        /// <summary>
        /// Registers a new political official based on PoliticalOfficalVM model 
        /// and infomration required for that user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>True or False</returns>
        Task<Response> AddPoliticalOfficialAsync(PoliticalOfficalVM model);

        /// <summary>
        /// Changes user's password based on their specified email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True or False</returns>
        Task<bool> ForgotPasswordAsync(string email);

        /// <summary>
        ///  Changes user's password based on their specified ResetPasswordVM model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Identity Result</returns>
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordVM model);

        /// <summary>
        /// Gets specified Logged in user
        /// </summary>
        /// <returns>Logged in user</returns>
        string GetLoginUser();

        /// <summary>
        /// Gets user email on specified email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True or False</returns>
        bool GetEmail(string email);

        Task<bool> IsInRoleAnetarIThjeshtWithId(string id);
        Task<bool> CheckUser(string email, string password);

        Task<bool> IsInSimpleRole(string email);

        Task<bool> IsInRoleKryetarIFshatit(string id);

        Task<bool> IsInRoleKryetarIFshatitWithEmail(string email);

        Task<bool> IsInRoleAnetarIThjeshtWithEmail(string email);

        Task<IdentityResult> ChangePassword(string password);

       Task<bool?> HasPasswordChange();

        Task<bool> IsEmailConfirmed(LoginVM model);

        Task<List<SuggetVoters>> GetVotersSuggest(string suggest, int muniId);
    }
}
