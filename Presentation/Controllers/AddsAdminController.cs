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

        public AddsAdminController(IUnitOfWork unitOfWork,
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


        [HttpGet, Authorize(Roles = "KryetarIPartise, KryetarIKomunes, KryetarIFshatit,AnetarIThjeshte")]
        public async Task<IActionResult> AddVoter()
        {

            try
            {
                VoterAddress();

                ViewBag.ChangePassword = TempData["ChangePassword"] as string;

                ViewBag.SaveAndOpenAdd = TempData["SaveAndOpenAdd"] as string;
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
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
                        if (userInRoleKryetarIFshatit)
                        {
                            TempData["mssgVillage"] = "U regjistruan me sukses!";
                            return RedirectToAction("Index", "Crm");


                        }
                        TempData["mssg"] = "U regjistuan me sukses!";
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
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);

            }

        }



        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public IActionResult PoliticalOffical()
        {
            try
            {
                PoliticalOfficialAddress();
                ViewBag.SaveAndOpenPolitical = TempData["SaveAndOpenPolitical"] as string;
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
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
                    if (!userInRoleKryetarIFshatit)
                    {
                        if (res.Status)
                        {
                            TempData["SaveAndClosePoliticalAdmin"] = "Te dhenat u ruajten me sukses!";
                            return RedirectToAction("Index", "Dashboard");
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

                    }
                    else
                    {
                        if (res.Status)
                        {
                            TempData["SaveAndClosePoliticalVillage"] = "Te dhenat u ruajten me sukses!";


                            return RedirectToAction("Index", "Crm");
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
                    }

                }

                PoliticalOfficialAddress();
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);
            }

        }





        public IActionResult Cancel() =>
            RedirectToAction("Index", "Dashboard");



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndOpenCase(RegisterVM register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ApplicationUser.RegisterVoterAsync(register);

                    if (res)
                    {
                        TempData["SaveAndOpenAdd"] = "U regjistruan me sukses!";
                        return RedirectToAction("AddVoter", "AddsAdmin");
                    }

                    VoterAddress();
                    return View("AddVoter", register);
                }
                VoterAddress();
                return View("AddVoter", register);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);
            }
        }

        public IActionResult CancelPoliticalOfficial()
        {
            TempData["UAnuluaPolitical"] = "U anulua!";

            return RedirectToAction("PoliticalOffical");
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
                        TempData["SaveAndOpenPolitical"] = "U regjistruan me sukses!";
                        return RedirectToAction("PoliticalOffical", "AddsAdmin");
                    }
                }
                PoliticalOfficialAddress();
                return View("PoliticalOffical", model);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);
            }
        }



        #region

        private void VoterAddress()
        {
            ViewBag.PS = new SelectList(StaticData.PoliticalSubjects().OrderBy(x => x.Value), "Key", "Value");
            ViewBag.municipalities = new SelectList(_unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(_unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(_unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(_unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(_unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(_unitOfWork.Street.GetAll(), "Id", "Name");
            ViewBag.administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
            ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");

            var data = ViewBag.PS;
        }

        private async void PoliticalOfficialAddress()
        {
            ViewBag.municipalities = new SelectList(_unitOfWork.Municipality.GetAll(), "Id", "Name");
            ViewBag.villages = new SelectList(_unitOfWork.Village.GetAll(), "Id", "Name");
            ViewBag.neigborhoods = new SelectList(_unitOfWork.Neighborhood.GetAll(), "Id", "Name");
            ViewBag.pollCenters = new SelectList(_unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
            ViewBag.blocks = new SelectList(_unitOfWork.Block.GetAll(), "Id", "Name");
            ViewBag.streets = new SelectList(_unitOfWork.Street.GetAll(), "Id", "Name");
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
                        if (!(item.Key == _roles.KryetarIPartise))
                            roles.Add(item);
                    }
                    else
                    {
                        if (!((item.Key == _roles.KryetarIPartise) || (item.Key == _roles.KryetarIKomunes)))
                            roles.Add(item);
                    }
                }
            }
            ViewBag.roles = (new SelectList((roles.Count <= 0 ? rolesFromDb : roles), "Key", "Value")).OrderBy(x => x.Text);
        }

        #endregion
    }
}
