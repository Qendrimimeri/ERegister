using Application.Repository.IRepository;
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
        public void Save()
        {
            _db.SaveChanges();
        }
        public async Task<string> GetVillageName(string userId) =>
        await _db.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == userId).Select(x => x.Address.Village.Name).FirstOrDefaultAsync();

    }
}
