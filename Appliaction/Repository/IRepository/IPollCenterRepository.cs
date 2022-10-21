using Application.ViewModels;
using Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IPollCenterRepository : IRepository<PollCenter>
    {
        Task<List<PollCenter>> GetAllAsync();

        Task<PollCenter> GetByVillageIdAsync(int id);

        Task<PollCenter> GetByNeighborhoodIdAsync(int id);

        Task<PollCenter> GetByMuniIdAsync(int id);

        Task<PollCenter> GetByCenterNumberAsync(string num);

        Task AddAsync(PollCenterVM model);

        Task AddByVillageAsync(PollCenterVM model);

        Task AddByNeiborhoodAsync(PollCenterVM model);
    }
}
