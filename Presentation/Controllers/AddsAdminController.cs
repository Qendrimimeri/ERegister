using Application.ViewModels;
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Domain.Data.Entities;

namespace Presentation.Controllers
{


    public class AddsAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;

        public AddsAdminController( IUnitOfWork unitOfWork ,IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> AddVoter()
        {
            ViewBag.PS = new SelectList( await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
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
                    TempData["success"] = "Registered successfuly!";
                    return RedirectToAction("Index", "dashboard");
                }
            }
            ViewBag.PS = new SelectList(await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
            return View("AddVoter",register);
        }


        [Authorize(Roles = "SuperAdmin,MunicipalityAdmin,LocalAdmin")]
        public async Task<IActionResult> PoliticalOffical()
        {
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.roles = new SelectList(await _unitOfWork.ApplicationUser.GetAllRolesAsync(), "Key", "Value");
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> PoliticalOffical(PoliticalOfficalVM model)
        {
            if (ModelState.IsValid)
            {
                var res = await _unitOfWork.Account.AddPoliticalOfficialAsync(model);
                if (res)
                    TempData["success"] = "Registered successfuly!";
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.roles = new SelectList(await _unitOfWork.ApplicationUser.GetAllRolesAsync(), "Key", "Value");
            return View();
        }




        public IActionResult AddPoliticalSubject()
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
        public IActionResult KqzRezult()
        {
            return View();
        }
    }
}
