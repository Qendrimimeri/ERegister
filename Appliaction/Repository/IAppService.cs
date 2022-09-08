using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliaction.Repository
{
    public interface IAppService
    {
        Task<List<PoliticalSubject>> GetAllPoliticalSubjectsAsync();

        Task<List<Municipality>> GetAllMunicipalitiesAsync();

        Task<List<Village>> GetAllVillagesAsync();

        Task<List<Block>> GetAllBlocksAsync();

        Task<List<Street>> GetAllStreetsAsync();

        Task<List<AdministrativeUnit>> GetAllAdministrativeUnitsAsync();

        Task<List<SuccessChance>> GetAllSuccessChancesAsync();

        Task<List<Neighborhood>> GetAllNeigborhoodsAsync();
    }
}
