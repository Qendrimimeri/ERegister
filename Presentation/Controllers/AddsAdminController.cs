using Application.ViewModels;
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Domain.Data.Entities;
using System.Net.NetworkInformation;

namespace Presentation.Controllers
{


    public class AddsAdminController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<AddsAdminController> _logger;

        public AddsAdminController( IUnitOfWork unitOfWork, 
                                    IHttpContextAccessor httpContext,
                                    ILogger<AddsAdminController> logger)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _logger = logger;
        }



        [Authorize(Roles= "KryetarIPartise, KryetarIKomunes, KryetarIFshatit,AnetarIThjeshte")]
        public IActionResult AddVoter()
        {
            VoterAddress();
            return View();
        }
      

        [HttpPost, ValidateAntiForgeryToken]
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

                VoterAddress();
                return View("AddVoter", register);
        }



        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> PoliticalOffical()
        {
            PoliticalOfficialAddress();
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PoliticalOffical(PoliticalOfficalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.Account.AddPoliticalOfficialAsync(model);
                    if (res)
                        TempData["success"] = "Registered successfuly!";
                    return RedirectToAction("Index", "Dashboard");
                }

                PoliticalOfficialAddress();
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public IActionResult Cancel()
        {
            TempData["success"] = "U anulua!";
            return RedirectToAction("Index","Dashboard");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult>SaveAndClose(ApplicationUser appuser)
        {
           await _unitOfWork.ApplicationUser.AddUserAsync(appuser);
             await _unitOfWork.Done();
            TempData["success"] = "U ruajt me sukses!";
            return RedirectToAction("Index", "Dashboard");
        }


        [HttpPost, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult>SaveAndOpenCase(RegisterVM register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.Account.RegisterVoterAsync(register);
                    if (res)
                    {
                        TempData["success"] = "Registered successfuly!";
                        return RedirectToAction("AddVoter", "AddsAdmin");
                    }

                }
                VoterAddress();
                return View("AddVoter", register);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured" ,err);
                return View(errorView);
            }

        }


        public IActionResult CancelPoliticalOfficial()
        {
            TempData["success"] = "U anulua!";
            return RedirectToAction("PoliticalOffical");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndClosePoliticalOfficial(ApplicationUser appuser)
        {
            try
            {
                await _unitOfWork.ApplicationUser.AddUserAsync(appuser);
                await _unitOfWork.Done();
                TempData["success"] = "U ruajt me sukses!";
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        [HttpPost, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> SaveAndOpenCasePoliticalOfficial(PoliticalOfficalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.Account.AddPoliticalOfficialAsync(model);
                    if (res)
                    {
                        TempData["success"] = "Registered successfuly!";
                        return RedirectToAction("PoliticalOffical", "AddsAdmin");
                    }
                }
                PoliticalOfficialAddress();
                return View("PoliticalOffical", model);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }



        #region

        private async void VoterAddress()
        {
            ViewBag.PS = new SelectList(await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
        }

        private async void PoliticalOfficialAddress()
        {
            ViewBag.municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
            var roles = new List<Application.Models.RoleModel>();

            bool userInrole = User.IsInRole("KryetarIKomunes");
            var rolesFromDb = await _unitOfWork.ApplicationUser.GetAllRolesAsync();
            if (userInrole)
                foreach (var item in rolesFromDb)
                    if (!(item.Value == "KryetarIPartise"))
                        roles.Add(item);

            ViewBag.roles = new SelectList((roles.Count <= 0 ? rolesFromDb : roles), "Key", "Value");
        }

        #endregion
    }
}
