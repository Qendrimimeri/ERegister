using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Repository
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        Task<bool> LoginAsync(LoginVM login);

        Task<bool> RegisterVoterAsync(RegisterVM register);

        Task<bool> AddPoliticalOfficialAsync(PoliticalOfficalVM model);

        Task<bool> ForgotPasswordAsync(string email);

        Task<IdentityResult> ResetPasswordAsync(ResetPasswordVM model);
    }
}
