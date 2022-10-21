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
    public class StreetRepository : Repository<Street>, IStreetRepository
    {
        private readonly ApplicationDbContext _db;

        public StreetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Street> GetByVillageAsync(int id) =>
            await _db.Streets.Where(x => x.VillageId == id).FirstOrDefaultAsync();


        public async Task AddByVillageAsync(AddStreetVM model)
        {
            await _db.Streets.AddAsync(new Street
            {
                Name = model.StreetName,
                VillageId = model.VillageId
            });
            await _db.SaveChangesAsync();
        }

        public async Task AddByNeiborgoodAsync(AddStreetVM model)
        {
            await _db.Streets.AddAsync(new Street
            {
                Name = model.StreetName,
                NeighborhoodId = model.NeighborhoodId
            });
            await _db.SaveChangesAsync();
        }


        public async Task<Street> GetByNeigborhoodAsync(int id) =>
            await _db.Streets.Where(n => n.NeighborhoodId == id).FirstOrDefaultAsync();
    }
}
