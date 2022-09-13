using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data.Entities;

namespace Application.Repository
{
    public interface IAccountRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetAppUsers();
        Task<bool> LoginAsync(LoginVM login);

        Task<bool> RegisterVoterAsync(RegisterVM register);
    }
}
