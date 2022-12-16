using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Infrastructure.Services;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Application.Models.Services;

namespace Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DashboardController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Toaster _toaster;

        public DashboardController(IUnitOfWork unitOfWork,
                                  UserManager<ApplicationUser> userManager,
                                  IWebHostEnvironment env,
                                  SignInManager<ApplicationUser> signInManager,
                                  ILogger<DashboardController> logger,
                                  IOptionsSnapshot<Toaster> toaster,
                                  IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _env = env;
            _signInManager = signInManager;
            _logger = logger;
            _httpContext = httpContext;
            _toaster = toaster.Value;
        }


        [HttpGet, Authorize(Roles = "KryetarIPartise, KryetarIKomunes, KryetarIFshatit, AnetarIThjeshte")]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.HasPasswordChange = await _unitOfWork.ApplicationUser.HasPasswordChange();
                if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = _httpContext.HttpContext.User.Identity;
                    var kryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatitWithEmail(user.Name);
                    var anetarIThjesht = await _unitOfWork.ApplicationUser.IsInRoleAnetarIThjeshtWithEmail(user.Name);

                    if (kryetarIFshatit)  return RedirectToAction("Index", "Crm");
                    if (anetarIThjesht) return RedirectToAction("AddVoter", "AddsAdmin");

                }
                ViewBag.SaveAndCloseCRM = TempData["SaveAndCloseCRM"] as string;

                ViewBag.SaveAndCloseProfile = TempData["SaveAndCloseProfile"] as string;
                ViewBag.ChangePassword = TempData["ChangePassword"] as string;

                ViewBag.AddPoliticalSaveAndClose = TempData["AddPoliticalSaveAndClose"] as string;
                ViewBag.mssg = TempData["mssg"] as string;
                return View();
            } 
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> PerformanceLocal()
        {
            try
            {
                var voters = await _unitOfWork.ApplicationUser.GetPerformanceLocalVoter();
                ViewBag.SaveAndCloseManage = TempData["SaveAndCloseManage"] as string;
                return View(voters);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }
        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> PerformanceNational()
        {
            try
            {
                var voters = await _unitOfWork.ApplicationUser.GetPerformanceNationalVoter();
                ViewBag.SaveAndCloseManage = TempData["SaveAndCloseManage"] as string;
                return View(voters);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> Reports(string id)
        //{
        //    try
        //    {
        //        var users = await _unitOfWork.ApplicationUser.GetUserByIdAsync(id);
        //        //ViewBag.PS = new SelectList(_unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
        //        ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
        //        ViewBag.actualStatus = new SelectList(StaticData.ActualStatus(), "Key", "Value");

        //        return View(users);
        //    }
        //    catch (Exception err)
        //    {
        //        _logger.LogError("An error has occured", err);
        //        return View(errorView);
        //    }
        //}


        //[HttpPost, ValidateAntiForgeryToken]
        //public async Task<IActionResult> Reports(VoterVM editVoter)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var users = await _unitOfWork.PollRelated.AddPollRelated(editVoter);
        //            TempData["SaveAndCloseManage"] = "Të dhënat u ndryshuan me sukses!";
        //            return RedirectToAction("Performance", "Dashboard");
        //        }
        //        return View();
        //    }
        //    catch (Exception err)
        //    {
        //        _logger.LogError("An error has occured", err);
        //        return View(errorView);
        //    }
        //}


        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes")]
        public IActionResult KqzResult()
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


        public IActionResult Cancel()
        {
            TempData[_toaster.Success] = "U anulua!";
            return RedirectToAction("KqzResult");
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndClose(Kqzregister appuser)
        {
            try
            {
                _unitOfWork.KqzRegister.Update(appuser);
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndOpenCase(Kqzregister appuser)
        {
            try
            {
                _unitOfWork.KqzRegister.Update(appuser);
                return RedirectToAction("KqzResult");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpGet]
        public async Task<IActionResult> BusinessUserProfile()
        {
            try
            {
                var res = await _userManager.GetUserAsync(User);
                var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Email);
                ViewBag.SaveAndCloseProfile = TempData["SaveAndCloseProfile"] as string;
                return View(user);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> BusinessUserProfile(ProfileVM editUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (editUser.Image == null)
                    {
                        var result = await _unitOfWork.ApplicationUser.EditUserProfile(editUser);
                        if (result)
                        {
                            var res = _userManager.GetUserAsync(User);
                            var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Result.Email);
                            TempData["SaveAndCloseProfile"] = "U regjistruan me sukses!";

                            return RedirectToAction("Index", "Dashboard");
                        }

                    }
                    else if (editUser.Image != null)
                    {
                        if (!editUser.Image.ContentType.Contains("image"))
                        {
                            TempData["error"] = "Formati duhet te jetë png ose jpg";
                            ViewBag.NotAllowedFormat = true;
                            return RedirectToAction("BusinessUserProfile");
                        }
                        var rootFilePath = _env.WebRootPath;
                        string filePath = Path.Combine(rootFilePath, "Document");
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);

                        var fileName = $"{Guid.NewGuid()}_{editUser.Image.FileName}";
                        var fullPath = Path.Combine(filePath, fileName);
                        var getUser = await _userManager.GetUserAsync(User);
                        if (getUser.ImgPath != null && getUser.ImgPath != "default.png")
                            if (System.IO.File.Exists(Path.Combine(filePath, getUser.ImgPath)))
                                System.IO.File.Delete(Path.Combine(filePath, getUser.ImgPath));

                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                            editUser.Image.CopyTo(fileStream);

                        var result = await _unitOfWork.ApplicationUser.EditProfileDetails(editUser, fileName);
                        if (result)
                        {
                            var user = await _unitOfWork.ApplicationUser.GetProfileDetails(getUser.Email);
                            TempData["SaveAndCloseProfile"] = "U regjistruan me sukses!";

                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpGet]
        public IActionResult ChangePassWord()
        {
            try
            {
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View();
                    }
                    await _signInManager.RefreshSignInAsync(user);
                    TempData["ChangePassword"] = "U ndryshua me sukses!";

                    return RedirectToAction("Index", "Dashboard");
                }
                return View(model);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }
    }
}
