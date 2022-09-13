using Application.Repository.IRepository;
using Domain.Data.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IAppService : IRepository<ApplicationUser>
    {
        Task<List<PoliticalSubject>> GetAllPoliticalSubjectsAsync();

        Task<List<Municipality>> GetAllMunicipalitiesAsync();

        Task<List<Village>> GetAllVillagesAsync();

        Task<List<Block>> GetAllBlocksAsync();

        Task<List<Street>> GetAllStreetsAsync();

        string[] GetAllAdministrativeUnitsAsync();

        string[] GetAllSuccessChancesAsync();

        Task<List<Neighborhood>> GetAllNeigborhoodsAsync();

        Task<List<PollCenter>> GetAllPollCentersAsync();
    }
}
