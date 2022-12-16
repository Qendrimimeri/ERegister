using Application.Models;
using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class KqzRegisterRepository: Repository<Kqzregister>, IKqzRegisterRepository
    {
        private readonly ApplicationDbContext _db;

        public KqzRegisterRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<Kqzregister> GetByMunicipalityAsync(int id) =>
            await _db.Kqzregisters.Where(v => v.MunicipalityId == id).FirstOrDefaultAsync();


        public async Task<Kqzregister> GetByVillageAsync(int id) =>
            await _db.Kqzregisters.Where(v => v.VillageId == id && v.ElectionType == "Zgjedhjet Nacionale")
                                  .FirstOrDefaultAsync();


        public async Task<Kqzregister> GetByNeigborhoodAsync(int id) =>
            await _db.Kqzregisters.Where(v => v.NeighborhoodId == id).FirstOrDefaultAsync();


        public async Task AddAsync(KqzRegisterVM model)
        {
            await _db.AddAsync(new Kqzregister
            {
                Id = model.Id,
                PoliticialSubject = model.PoliticialSubject,
                MunicipalityId = model.MunicipalityId,
                NoOfvotes = model.NoOfvotes,
                PollCenterId = model.PollCenterId,
                DataCreated = model.DataCreated,
                VillageId = model.VillageId,
                NeighborhoodId = model.NeighborhoodId,
                ElectionType = model.ElectionType
            });
            await _db.SaveChangesAsync();
        }

        public async Task<List<int?>> KqzValidationAsync(int id) => 
            await _db.Kqzregisters.Where(x => x.PollCenterId == id).Select(x => x.NoOfvotes).ToListAsync();
    }
}
