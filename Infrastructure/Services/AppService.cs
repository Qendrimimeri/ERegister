using Appliaction.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AppService : IAppService
    {
        private readonly ApplicationDbContext _context;

        public AppService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PoliticalSubject>> GetAllPoliticalSubjectsAsync() 
            =>  await _context.PoliticalSubjects.ToListAsync();

        public async Task<List<Municipality>> GetAllMunicipalitiesAsync()
            => await _context.Municipalities.ToListAsync();

        public async Task<List<Village>> GetAllVillagesAsync()
            => await _context.Villages.ToListAsync();

        public async Task<List<Neighborhood>> GetAllNeigborhoodsAsync()
            => await _context.Neighborhoods.ToListAsync();

        public async Task<List<Block>> GetAllBlocksAsync()
            => await _context.Blocks.ToListAsync();

        public async Task<List<Street>> GetAllStreetsAsync()
            => await _context.Streets.ToListAsync();

        public async Task<List<AdministrativeUnit>> GetAllAdministrativeUnitsAsync()
            => await _context.AdministrativeUnits.ToListAsync();

        public async Task<List<SuccessChance>> GetAllSuccessChancesAsync()
            => await _context.SuccessChances.ToListAsync();
    }
}
