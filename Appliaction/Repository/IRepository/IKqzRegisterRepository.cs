using Application.ViewModels;
using Domain.Data.Entities;

namespace Application.Repository.IRepository
{
    public interface IKqzRegisterRepository :IRepository<Kqzregister>
    {
        Task<Kqzregister> GetByMunicipalityAsync(int id);

        /// <summary>
        /// Updates KqzResult based on specified KqzRegister model
        /// </summary>
        /// <param name="kqz"></param>
        /// <returns>KqzRegister result</returns>
        Task<Kqzregister> UpdateKqzAsync(Kqzregister kqz);

        Task<Kqzregister> GetByVillageAsync(int id);

        Task<Kqzregister> GetByNeigborhoodAsync(int id);

        Task AddAsync(KqzRegisterVM model);

        Task<List<int?>> KqzValidationAsync(int id);
    }
}
