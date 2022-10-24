using Application.Repository.IRepository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class BlockRepository:Repository<Block>,IBlockRepository
    {
        private readonly ApplicationDbContext _db;

        public BlockRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Block> GetByMunicipalityAsync(int id) =>
            await _db.Blocks.Where(x => x.MunicipalityId == id).FirstOrDefaultAsync();


        public async Task AddAsync(AddBlockVM model)
        {
            await _db.Blocks.AddAsync(new Block
            {
                Name = model.BlockName,
                MunicipalityId = model.MunicipalityId
            });
            await _db.SaveChangesAsync();
        }
    }
}
