using Application.Models;
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
    public class PoliticalSubjectRepository : Repository<PoliticalSubject>, IPoliticalSubjectRepository
    {
        private readonly ApplicationDbContext _db;

        public PoliticalSubjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PoliticalSubject>> GetPoliticalSubjectsAsync() 
            => await _db.PoliticalSubjects.ToListAsync();


        public async Task<PoliticalSubject> GetByNameAsync(string name) =>
            await _db.PoliticalSubjects.Where(x => x.Name == name).FirstOrDefaultAsync();


        public async Task AddAsync(NameModel model)
        {
            await _db.PoliticalSubjects.AddAsync(new PoliticalSubject
            {
                Name = model.Text
            });
            await _db.SaveChangesAsync();
        }
    }
}
