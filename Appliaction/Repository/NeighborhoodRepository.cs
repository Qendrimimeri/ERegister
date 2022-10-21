using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        private readonly ApplicationDbContext _db;

        public NeighborhoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Neighborhood> GetByIdAsync(int id) =>
            await _db.Neighborhoods.Where(x => x.Id == id).FirstOrDefaultAsync();


        public async Task<List<Neighborhood>> GetAllAsync() =>
            await _db.Neighborhoods.ToListAsync();


        public async Task<Neighborhood> GetByMunicipalityAsync(int id) =>
            await _db.Neighborhoods.Where(x => x.MunicipalityId == id).FirstOrDefaultAsync();


        public async Task<Neighborhood> GetByVillageAsync(int id) =>
            await _db.Neighborhoods.Where(x => x.VillageId == id).FirstOrDefaultAsync();


        public async Task AddAsync(AddNeighborhoodVM model)
        {
            await _db.Neighborhoods.AddAsync(new Neighborhood
            {
                Name = model.NeighborhoodName,
                MunicipalityId = model.MunicipalityId
            });
            await _db.SaveChangesAsync();
        }

        public async Task AddByVillageAsync(AddNeighborhoodVM model)
        {
            await _db.Neighborhoods.AddAsync(new Neighborhood
            {
                Name = model.NeighborhoodName,
                VillageId = model.VillageId
            });
            await _db.SaveChangesAsync();
        }

        public async Task<string> GetNeigborhoodName(string userId) =>
            await _db.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == userId).Select(x => x.Address.Neighborhood.Name).FirstOrDefaultAsync();

    }
    
}
