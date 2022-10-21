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
    public class VillageRepository : Repository<Village>, IVillageRepository
    {
        private readonly ApplicationDbContext _db;

        public VillageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Village>> GetAllAsync() =>
            await _db.Villages.ToListAsync();


        public async Task<List<Village>> GetByMunicipalityAsync(int id) =>
            await _db.Villages.Where( x=> x.MunicipalityId == id).ToListAsync();


        public async Task AddAsync(AddVillageVM model)
        {
            _db.Villages.Add(new Village
            {
                Name = model.VillageName,
                MunicipalityId = model.MunicipalityId
            });
            _db.SaveChanges();
        }

    }
}
