using Application.ViewModels;
using Domain.Data.Entities;

namespace Application.Repository.IRepository
{
    public interface IKqzRegisterRepository :IRepository<Kqzregister>
    {
        Task<Kqzregister> GetByMunicipalityAsync(int id);

        Task<Kqzregister> GetByVillageAsync(int id);

        Task<Kqzregister> GetByNeigborhoodAsync(int id);

        Task AddAsync(KqzRegisterVM model);

        Task<List<int?>> KqzValidationAsync(int id);
    }
}
