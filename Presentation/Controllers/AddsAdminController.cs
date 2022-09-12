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
        private readonly IUnitOfWork _unitOfWork;

        public AddsAdminController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> AddVoter()
        {
            //PS ==> Political Subjects
            var PS = new SelectList( await _unitOfWork.AppService.GetAllPoliticalSubjectsAsync(), "Id", "Name");
            ViewBag.PS = PS;

            var municipalities = new SelectList(await _unitOfWork.AppService.GetAllMunicipalitiesAsync(), "Id", "Name");
            ViewBag.municipalities = municipalities;

            var villages = new SelectList(await _unitOfWork.AppService.GetAllVillagesAsync(), "Id", "Name");
            ViewBag.villages = villages;

            var neigborhoods = new SelectList(await _unitOfWork.AppService.GetAllNeigborhoodsAsync(), "Id", "Name");
            ViewBag.neigborhoods = neigborhoods;

            var pollCenters = new SelectList(await _unitOfWork.AppService.GetAllPollCentersAsync(), "Id", "CenterNumber");
            ViewBag.pollCenters = pollCenters;

            var blocks = new SelectList(await _unitOfWork.AppService.GetAllBlocksAsync(), "Id", "Name");
            ViewBag.blocks = blocks;

            var streets = new SelectList(await _unitOfWork.AppService.GetAllStreetsAsync(), "Id", "Name");
            ViewBag.streets = streets;

            var administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.administrativeUnits = administrativeUnits;

            var successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
            ViewBag.successChances = successChances;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (ModelState.IsValid)
            {
                var res = await _unitOfWork.Account.RegisterVoterAsync(register);
                if (res)
                {
                    return RedirectToAction("Index", "dashboard");
                }
            }
            return RedirectToAction("AddVoter");
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
