using Appliaction.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<string> GetAllPoliticalSubjectsAsync()
        {
            return PoliticialSubjects();
        }

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

        public string[] GetAllAdministrativeUnitsAsync()
        {
            return AdministrativeUnits();
        }

        public string[] GetAllSuccessChancesAsync()
        {
            return SuccessChances();
        }




        private static List<string> PoliticialSubjects()
        {
            //var psList = new List<KeyValuePair<string, int>>();
            //psList.Add(new KeyValuePair<string, int>("VV", 1));
            //psList.Add(new KeyValuePair<string, int>("PDK", 2));
            //psList.Add(new KeyValuePair<string, int>("LDK", 3));

            string[] politicalSubjects = { "VV", "PDK", "LDK", "AAK" };
            List<string> psList = politicalSubjects.ToList();
            return psList;

            string[] months = { "January", "February", "March", "April",  "November", "December" };
            var query = months.Select((r, index) => new { Text = r, Value = index });

        }

        private static string[] AdministrativeUnits()
        {
            string[] administrativeUnits = { "Sherbim Publik", "Sherbim Privat" };
            return administrativeUnits;
        }

        private static string[] GeneralDemands()
        {
            string[] generalDemands = { "Infrastrukture", "Qerdhe", "Ujsjelles" };
            return generalDemands;
        }

        private static string[] GeneralReasons()
        {
            string[] generalReasons = { "Bindje Politike", "Familja", "Shoqria" };
            return generalReasons;
        }

        private static string[] SuccessChances()
        {
            string[] successChances = { "0", "25", "50", "75", "100" };
            return successChances;
        }

        private static string[] StreetSources()
        {
            string[] streetSources = { "Qytet", "Fshat", "Lagje" };
            return streetSources;
        }
    }
}
