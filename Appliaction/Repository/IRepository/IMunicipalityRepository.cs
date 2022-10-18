using Domain.Data.Entities;

namespace Application.Repository.IRepository
{
    public interface IMunicipalityRepository:IRepository<Municipality>
    {
        Task<Municipality> GetByName(string name);

        Task<Municipality> GetMuniOfUser(string Id);

        Task<List<Municipality>> GetAllCities();
    }
}
