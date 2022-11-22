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
                 _unitOfWork.Dispose();

                if (res == null)
                {
                    ViewBag.Name = name;
                    ViewBag.UserNull = "nuk ka te dhena";
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
                var userId = _unitOfWork.ApplicationUser.GetLoginUser();
                var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");
                TempData[_toaster.Success] = "U ruajt me sukses!";
                 _unitOfWork.Dispose();

                if (userInRoleKryetarIFshatit)
                    return RedirectToAction("Index", "Crm");
                return RedirectToAction("Index", "dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }



        public IActionResult AutoComplete(string prefix, int id, string role)
        {
            try
            {


                if (role == "KryetarIPartise")
                {

                    var users = (from a in this._context.ApplicationUsers

                                 from d in this._context.Roles
                                 from b in this._context.UserRoles.Where(x => d.Name == "SimpleRole"
                                                                               && x.RoleId == d.Id
                                                                               && a.FullName.StartsWith(prefix)
                                                                               && a.Id == x.UserId)

                                 select new
                                 {
                                     label = a.FullName,
                                     val = a.Id
                                 }).ToList();

                    return Json(users);

                }
                else
                {


                    var users = (from a in this._context.ApplicationUsers
                                 from c in this._context.Addresses
                                 from d in this._context.Roles
                                 from b in this._context.UserRoles.Where(x => d.Name == "SimpleRole"
                                                                               && x.RoleId == d.Id
                                                                               && a.FullName.StartsWith(prefix)
                                                                               && a.Id == x.UserId
                                                                               && c.Id == a.AddressId
                                                                               && c.MunicipalityId == id
                                                                               )
                                 select new
                                 {
                                     label = a.FullName,
                                     val = a.Id
                                 }).ToList();

                    return Json(users);
                }


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
                var userId = _unitOfWork.ApplicationUser.GetLoginUser();
                var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");
                TempData[_toaster.Success] = "U ruajt me sukses!";
                 _unitOfWork.Dispose();

                if (userInRoleKryetarIFshatit)
                    return RedirectToAction("Index", "Crm");
                return RedirectToAction("Index", "dashboard");

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
                var userId = _unitOfWork.ApplicationUser.GetLoginUser();
                var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
                _unitOfWork.PollRelated.Update(pollRelated);
                 _unitOfWork.Dispose();
                TempData[_toaster.Success] = "U ruajt me sukses!";
                if (userInRoleKryetarIFshatit)
                    return RedirectToAction("Index", "Crm");
                return RedirectToAction("Index", "dashboard");
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
