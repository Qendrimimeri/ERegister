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
        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task<int> GetMuniNameByUserIdAsync(string Id)
            => (int) await _db.Users.Where(x => x.Id == Id).Select(x => x.Address.MunicipalityId).FirstOrDefaultAsync();
    }
}

    
