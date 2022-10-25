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
    public class MunicipalityRepository : Repository<Municipality>, IMunicipalityRepository
    {
        private readonly ApplicationDbContext _db;

        public MunicipalityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Municipality> GetByName(string name)
        {
            var res = _db.Municipalities.Where(x => x.Name == name).FirstOrDefault();
            return (res);
        }

        public async Task<Municipality> GetMuniOfUser(string id)
        {
            if (id.Contains('@'))
                return await _db.Users.Where(x => x.Email == id).Select(x => x.Address.Municipality).FirstOrDefaultAsync();
            return await _db.Users.Where(x => x.Id == id).Select(x => x.Address.Municipality).FirstOrDefaultAsync();
        }

        public async Task<List<Municipality>> GetAllMunicipalityAsync()
            => await _db.Municipalities.ToListAsync();

        public async Task<string> GetMuniName(string userId) =>
            await _db.ApplicationUsers.Include(x => x.Address).Where(x => x.Id == userId).Select(x => x.Address.Municipality.Name).FirstOrDefaultAsync();
    }
}

    
