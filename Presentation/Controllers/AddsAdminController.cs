using Application.ViewModels;
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Domain.Data.Entities;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Options;
using System.Web.Providers.Entities;
using Application.Models.Services;

namespace Presentation.Controllers
{


    public class AddsAdminController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<AddsAdminController> _logger;
        private readonly Toaster _toaster;
        private readonly Roles _roles;

        public AddsAdminController( IUnitOfWork unitOfWork, 
                                    IHttpContextAccessor httpContext,
                                    ILogger<AddsAdminController> logger,
                                    IOptionsSnapshot<Roles> roles, 
                                    IOptionsSnapshot<Toaster> toaster)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
            _logger = logger;
            _toaster = toaster.Value;
            _roles = roles.Value;
        }


        [HttpGet, Authorize(Roles= "KryetarIPartise, KryetarIKomunes, KryetarIFshatit,AnetarIThjeshte")]
        public async Task<IActionResult> AddVoter()
        {
            
            try
            {
                ViewBag.HasPasswordChange = await _unitOfWork.ApplicationUser.HasPasswordChange();
                VoterAddress();
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }

        }
      

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var userId = _unitOfWork.ApplicationUser.GetLoginUser();
                    var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
                    var res = await _unitOfWork.ApplicationUser.RegisterVoterAsync(register);

                    if (res)
                    {
                        TempData[_toaster.Success] = "U regjistrua me sukses!";
                        if (userInRoleKryetarIFshatit)
                            return RedirectToAction("Index", "Crm");
                        return RedirectToAction("Index", "dashboard");
                    }
                    else
                    {
                        ViewBag.UserExist = "Email i dhënë ekziston në sistem!";
                        VoterAddress();
                        return View("AddVoter", register);
                    }
                }

                VoterAddress();
                return View("AddVoter", register);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }

        }



        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public IActionResult PoliticalOffical()
        {
            try
            {
                PoliticalOfficialAddress();
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
}


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PoliticalOffical(PoliticalOfficalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = _unitOfWork.ApplicationUser.GetLoginUser();
                    var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
                    var res = await _unitOfWork.ApplicationUser.AddPoliticalOfficialAsync(model);
                    if (res.Status)
                    {
                        TempData[_toaster.Success] = "U regjistrua me sukses!";
                    }
                    else if (res.Message == "Ju lutem plotsoni rezultate lidhur me KQZ-n")
                    {
                        PoliticalOfficialAddress();
                        ViewBag.KqzValidation = true;
                        return View();
                    }
                    else 
                    {
                        ModelState.AddModelError("", "Ky email ekziston!");
                        ViewBag.EmailExist = "nuk ka email";
                        PoliticalOfficialAddress();
                        return View();
                    }
                    if (userInRoleKryetarIFshatit)
                        return RedirectToAction("Index", "Crm");
                    return RedirectToAction("Index", "dashboard");
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
            TempData[_toaster.Success] = "U anulua!";
            return RedirectToAction("Index","Dashboard");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult>SaveAndClose(ApplicationUser appuser)
        {
            try
            {
                await _unitOfWork.ApplicationUser.AddUserAsync(appuser);

                TempData[_toaster.Success] = "U ruajt me sukses!";

                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }

        [HttpPost]
        public async Task<IActionResult>SaveAndOpenCase(RegisterVM register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ApplicationUser.RegisterVoterAsync(register);

                    if (res)
                    {
                        TempData[_toaster.Success] = "U ruajt me sukses!";
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
            TempData[_toaster.Success] = "U anulua!";
            return RedirectToAction("PoliticalOffical");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndClosePoliticalOfficial(ApplicationUser appuser)
        {
            try
            {
                await _unitOfWork.ApplicationUser.AddUserAsync(appuser);

                TempData[_toaster.Success] = "U ruajt me sukses!";
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        [HttpPost, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit,AnetarIThjeshte")]
        public async Task<IActionResult> SaveAndOpenCasePoliticalOfficial(PoliticalOfficalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ApplicationUser.AddPoliticalOfficialAsync(model);

                    if (res.Status)
                    {
                        TempData[_toaster.Success] = "U regjistrua me sukses!";
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

            ViewBag.PS = new SelectList( _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.municipalities = new SelectList( _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList( _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList( _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList( _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList( _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList( _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
        }

        private async void PoliticalOfficialAddress()
        {
            ViewBag.municipalities = new SelectList( _unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList( _unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList( _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList( _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList( _unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList( _unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.electionType = new SelectList(StaticData.ElectionType(), "Key", "Value");
            var roles = new List<Application.Models.KeyValueModel>();

            bool komunes = User.IsInRole("KryetarIKomunes");
            bool fshatit = User.IsInRole("KryetarIFshatit");
            var rolesFromDb = await _unitOfWork.ApplicationUser.GetAllRolesAsync();

            if (komunes || fshatit)
            {
                foreach (var item in rolesFromDb)
                {
                    if (komunes)
                    {
                        if (!(item.Value == "Kryetar i partise"))
                            roles.Add(item);
                    }
                    else
                    {
                        if (!((item.Value == "Kryetar i partise") || (item.Value == "Kryetar i komunes")))
                            roles.Add(item);
                    }
                }
            }
            ViewBag.roles = (new SelectList((roles.Count <= 0 ? rolesFromDb : roles), "Key", "Value")).OrderBy(x => x.Text);
        }

        #endregion
    }
}
