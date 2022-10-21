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
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        private readonly ApplicationDbContext _db;

        public NeighborhoodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task<string> GetNeigborhoodName(string userId) =>
            await _db.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == userId).Select(x => x.Address.Neighborhood.Name).FirstOrDefaultAsync();

    }
    
}
