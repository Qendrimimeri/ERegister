using Appliaction.Repository;
using Appliaction.ViewModels;
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Presentation.Controllers
{
    public class AddsAdminController : Controller
    {
        private readonly IAppService _appService;
        private readonly IUnitOfWork _unitOfWork;

        public AddsAdminController(IAppService appService, IUnitOfWork unitOfWork)
        {
            _appService = appService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> AddVoter()
        {
            //PS ==> Political Subjects
            //var PS = new SelectList( _appService.GetAllPoliticalSubjectsAsync());
            //ViewBag.PS = PS;

            //var municipalities = new SelectList(await _appService.GetAllMunicipalitiesAsync(), "Id", "Name");
            //ViewBag.municipalities = municipalities;

            //var villages = new SelectList(await _appService.GetAllVillagesAsync(), "Id", "Name");
            //ViewBag.villages = villages;

            //var neigborhoods = new SelectList(await _appService.GetAllNeigborhoodsAsync(), "Id", "Name");
            //ViewBag.neigborhoods = neigborhoods;

            //var blocks = new SelectList(await _appService.GetAllBlocksAsync(), "Id", "Name");
            //ViewBag.blocks = blocks;

            //var streets = new SelectList(await _appService.GetAllStreetsAsync(), "Id", "Name");
            //ViewBag.streets = streets;

            var administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.administrativeUnits = administrativeUnits;

            //var successChances = new SelectList(await _appService.GetAllSuccessChancesAsync(), "Id", "Name");
            //ViewBag.successChances = successChances;

            return View();
        }


        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                var res = await _unitOfWork.AccountRepository.RegisterVoterAsync(register);
                if (res == true)
                {
                    return RedirectToAction("Index", "dashboard");
                }
            }
            return View(ModelState);
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
        public IActionResult EditPoliticalSubjectTest()
        {
            return View();
        }
        public IActionResult AddPoliticalSubjectTest()
        {
            return View();
        }
    }
}
