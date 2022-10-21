using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IVillageRepository:IRepository<Village>
    {
        Task<List<Village>> GetAllAsync();

        Task<List<Village>> GetByMunicipalityAsync(int id);

        Task AddAsync(AddVillageVM model);
    }
}
