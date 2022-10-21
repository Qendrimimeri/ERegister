using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class PollCenterRepository : Repository<PollCenter>, IPollCenterRepository
    {
        private readonly ApplicationDbContext _db;

        public PollCenterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<List<PollCenter>> GetAllAsync() =>
            await _db.PollCenters.ToListAsync();


        public async Task<PollCenter> GetByVillageIdAsync(int id) =>
            await _db.PollCenters.Where(v => v.VillageId == id).FirstOrDefaultAsync();


        public async Task<PollCenter> GetByNeighborhoodIdAsync(int id) =>
            await _db.PollCenters.Where(x => x.NeighborhoodId == id).FirstOrDefaultAsync();


        public async Task<PollCenter> GetByMuniIdAsync(int id) =>
            await _db.PollCenters.Where(x => x.MunicipalitydId == id).FirstOrDefaultAsync();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<PollCenter> GetByCenterNumberAsync(string num) =>
            await _db.PollCenters.Where(x => x.CenterNumber == num).FirstOrDefaultAsync();

        
        public async Task AddAsync(PollCenterVM model)
        {
            await _db.PollCenters.AddAsync(new PollCenter
            {
                Id = model.Id,
                CenterNumber = model.CenterNumber,
                CenterName = model.CenterName,
                MunicipalitydId = model.MunicipalitydId,
                NeighborhoodId = model.NeighborhoodId,
                VillageId = model.VillageId

            });
            await _db.SaveChangesAsync();
        }


        public async Task AddByVillageAsync(PollCenterVM model)
        {
            await _db.PollCenters.AddAsync(new PollCenter
            {
                CenterNumber = model.CenterNumber,
                VillageId = model.VillageId
            });
            await _db.SaveChangesAsync();
        }


        public async Task AddByNeiborhoodAsync(PollCenterVM model)
        {
            await _db.PollCenters.AddAsync(new PollCenter
            {
                CenterNumber = model.CenterNumber,
                NeighborhoodId = model.NeighborhoodId
            });
            await _db.SaveChangesAsync();
        }
    }
}
