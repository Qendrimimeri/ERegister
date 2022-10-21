using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface INeighborhoodRepository:IRepository<Neighborhood>
    {
        Task<Neighborhood> GetByIdAsync(int id);

        Task<Neighborhood> GetByMunicipalityAsync(int id);

        Task<Neighborhood> GetByVillageAsync(int id);

        Task<List<Neighborhood>> GetAllAsync();

        Task AddAsync(AddNeighborhoodVM model);

        Task AddByVillageAsync(AddNeighborhoodVM model);
        
        Task<string> GetNeigborhoodName(string userId);
    }
}
