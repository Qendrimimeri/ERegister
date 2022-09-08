using Appliaction.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
    public class AddsAdminController : Controller
    {
        private readonly IAppService _appService;

        public AddsAdminController(IAppService appService)
        {
           _appService = appService;
        }
        public async Task<IActionResult> AddVoter()
        {
            // PS ==> Political Subjects
            var PS = new SelectList(await _appService.GetAllPoliticalSubjectsAsync(), "Id", "Name");
            ViewBag.PS = PS;

            var municipalities = new SelectList(await _appService.GetAllMunicipalitiesAsync(), "Id", "Name");
            ViewBag.municipalities = municipalities;

            var villages = new SelectList(await _appService.GetAllVillagesAsync(), "Id", "Name");
            ViewBag.villages = villages;

            var neigborhoods = new SelectList(await _appService.GetAllNeigborhoodsAsync(), "Id", "Name");
            ViewBag.neigborhoods = neigborhoods;

            var blocks = new SelectList(await _appService.GetAllBlocksAsync(), "Id", "Name");
            ViewBag.blocks = blocks;

            var streets = new SelectList(await _appService.GetAllStreetsAsync(), "Id", "Name");
            ViewBag.streets = streets;

            var administrativeUnits = new SelectList(await _appService.GetAllAdministrativeUnitsAsync(), "Id", "Description");
            ViewBag.administrativeUnits = administrativeUnits;

            var successChances = new SelectList(await _appService.GetAllSuccessChancesAsync(), "Id", "Name");
            ViewBag.successChances = successChances;

            return View();
        }

       public IActionResult AddPoliticalSubject()
       {
             
           return View();
       }


        public IActionResult EditPoliticalSubject()
        {
            return View();
        }

        public IActionResult AddBlock()
        {
            return View();
        }
        public IActionResult AddStreet()
        {
            return View();
        }
        public IActionResult AddNeighborhood()
        {
            return View();
        }
    }
}
