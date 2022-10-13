using Application.Models.Services;
using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Presentation.Controllers

{
    [Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]

    public class CrmController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly Toaster _toaster;
        private readonly ILogger<CrmController> _logger;

        public CrmController(IUnitOfWork unitOfWork,
                             ILogger<CrmController> logger,
                             ApplicationDbContext context,
                             IOptionsSnapshot<Toaster> toaster)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = context;
            _toaster = toaster.Value;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public async Task<IActionResult> Voters(string name)
        {
            try
            {
                Data();
                var res = await _unitOfWork.ApplicationUser.GetVoterInfoAsync(name);
                if (res == null)
                {
                    ViewBag.Name = name;
                    ViewBag.UserNull = "Nuk ka te dhena";
                }
                return PartialView("_Voters", (await _unitOfWork.ApplicationUser.GetVoterInfoAsync(name)));
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Voters(VoterDetailsVM model)
        {
            try
            {
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");

                TempData[_toaster.Success] = "U ruajt me sukses!";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }



        public IActionResult AutoComplete(string prefix)
        {
            try
            {
                var users = (from user in this._context.ApplicationUsers
                             where user.FullName.StartsWith(prefix)
                             select new
                             {
                                 label = user.FullName,
                                 val = user.Id
                             }).ToList();

                return Json(users);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return BadRequest();
            }

        }


        public IActionResult Cancel()
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }

        }


        public async Task<IActionResult> SaveAndClose(VoterDetailsVM model)
        {
            try
            {
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");

                TempData[_toaster.Success] = "U ruajt me sukses!";
                return RedirectToAction("Index","Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public async Task<IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            try
            {
                _unitOfWork.PollRelated.Update(pollRelated);
                await _unitOfWork.Done();
                TempData[_toaster.Success] = "U ruajt me sukses!";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public IActionResult GeneralReasons() => View();


        public IActionResult AddHelper() => View();


        public IActionResult OpenCases() => View();


        #region API CALL


        public async Task<bool> SpecificDemand([FromQuery] string reason, string userId)
            => await _unitOfWork.PollRelated.updateSpecificDemandAsync(reason, userId);

        #endregion


        #region ViewBag Data
        
        private void Data()
        {
            ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
            ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
            ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");
        }
        
        #endregion
    }
}
