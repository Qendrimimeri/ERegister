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
        //List<string> GetAllPoliticalSubjectsAsync();

        Task<List<Municipality>> GetAllMunicipalitiesAsync();

        Task<List<Village>> GetAllVillagesAsync();

        Task<List<Block>> GetAllBlocksAsync();

        Task<List<Street>> GetAllStreetsAsync();

        string[] GetAllAdministrativeUnitsAsync();

        string[] GetAllSuccessChancesAsync();

        Task<List<Neighborhood>> GetAllNeigborhoodsAsync();
    }
}
