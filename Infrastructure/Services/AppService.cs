using Appliaction.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AppService : Repository<ApplicationUser> ,IAppService
    {
        private readonly ApplicationDbContext _context;
        private ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppService(ApplicationDbContext context, ILogger logger, 
                          UserManager<ApplicationUser> userManager) : base(context, logger, userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<List<PoliticalSubject>> GetAllPoliticalSubjectsAsync()
            => await _context.PoliticalSubjects.ToListAsync();

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

        public async Task<List<PollCenter>> GetAllPollCentersAsync()
            => await _context.PollCenters.ToListAsync();

        public string[] GetAllAdministrativeUnitsAsync()
        {
            return AdministrativeUnits();
        }

        public string[] GetAllSuccessChancesAsync()
        {
            return SuccessChances();
        }




        //private static List<string> PoliticialSubjects()
        //{
        //    var psList = new List<KeyValuePair<string, int>>();
        //    psList.Add(new KeyValuePair<string, int>("VV", 1));
        //    psList.Add(new KeyValuePair<string, int>("PDK", 2));
        //    psList.Add(new KeyValuePair<string, int>("LDK", 3));

        //    string[] politicalSubjects = { "VV", "PDK", "LDK", "AAK" };
        //    List<string> psList = politicalSubjects.ToList();
        //    return psList;

        //    List<SelectListItem> politicalSubjects = new List<SelectListItem>();
        //    for (int i = 0; i <= postStatus.Length; i++)
        //    {
        //        postStatusList.Add(new SelectListItem { Text = postStatus[i], Value = postStatus[i] });
        //    }
        //    ViewData["postStatus"] = postStatusList;
        //}

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
