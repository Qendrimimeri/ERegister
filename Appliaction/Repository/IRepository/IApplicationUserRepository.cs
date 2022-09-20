using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<List<PersonVM>> GetPersonInfoAsync();

        Task<ApplicationUser> FindUserById(string id);

        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser userIdentity, string token);
    }
}
