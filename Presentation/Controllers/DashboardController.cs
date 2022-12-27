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
using NuGet.Protocol;
using Microsoft.Win32;
using System.Reflection;
using iText.Html2pdf;

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
                if (!await _unitOfWork.ApplicationUser.HasPasswordChange()) return RedirectToAction("ChangePassword", "Home");
                if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    var user = _httpContext.HttpContext.User.Identity;
                    var kryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatitWithEmail(user.Name);
                    var anetarIThjesht = await _unitOfWork.ApplicationUser.IsInRoleAnetarIThjeshtWithEmail(user.Name);

                    if (kryetarIFshatit) return RedirectToAction("Index", "Crm");
                    if (anetarIThjesht) return RedirectToAction("AddVoter", "AddsAdmin");

                }
                ViewBag.AddPoliticalSaveAndCloseVillage = TempData["AddPoliticalSaveAndCloseVillage"] as string;
                ViewBag.SaveAndCloseCRM = TempData["SaveAndCloseCRM"] as string;
                ViewBag.SaveAndCloseProfile = TempData["SaveAndCloseProfile"] as string;
                ViewBag.ChangePassword = TempData["ChangePassword"] as string;
                ViewBag.SaveAndClosePoliticalAdmin = TempData["SaveAndClosePoliticalAdmin"] as string;
                ViewBag.mssg = TempData["mssg"] as string;
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);
            }
        }

        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> PerformanceLocal()
        {
            try
            {
                var voters = await _unitOfWork.ApplicationUser.GetPerformanceLocalVoter();
                return View(voters);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
                return View(errorView);
            }
        }
        [HttpGet, Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
        public async Task<IActionResult> PerformanceNational()
        {
            try
            {
                var voters = await _unitOfWork.ApplicationUser.GetPerformanceNationalVoter();
                return View(voters);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err.Message);
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
                _logger.LogError("An error has occured", err.Message);
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
                _logger.LogError("An error has occurred", err.Message);
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
                _logger.LogError("An error has occurred", err.Message);
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

                            return RedirectToAction("BusinessUserProfile", "Dashboard");
                        }

                    }
                    else if (editUser.Image != null)
                    {
                        if (!editUser.Image.ContentType.Contains("image") || editUser.Image.ContentType.Contains("image/svg+xml"))
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

                            return RedirectToAction("BusinessUserProfile", "Dashboard");
                        }
                    }
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err.Message);
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
                _logger.LogError("An error has occurred", err.Message);
                return View(errorView);
            }
        }

        [HttpPost]
        public ActionResult Export(string GridHtml)
        {
            string style = @"
                  <style>
                    body {
                      font-family: Arial, sans-serif;
                      font-size: 14px;
                    }
                    table {
                      border-collapse: collapse;
                      width: 100%;
                    }
                    th, td {
                      border: 1px solid #dddddd;
                      text-align: middle;
                      padding: 8px;
                    }
                    //tr:nth-child(even) {
                    //  background-color:#e9f0f2;
                    //}
                   th{
                      background-color:#dee2e3 !important;
                    }
                    ul {
                      list-style-type: none;
                    }
                     li {
                          display: none;
                       }
                        .form-select:focus {
                          outline: none;
                        }
                       .form-select{ 
                          display:none !important;
                          border: none !important;
                        }
                              .dataTables_info{ 
                                  display:none !important;
                                  border: none !important;
                                }
                       
                        

                  </style>
                ";
            string fullyQualifiedFileName = Path.Combine(_env.WebRootPath, "images", "E-Vota.png");
            string imageData = Convert.ToBase64String(System.IO.File.ReadAllBytes(fullyQualifiedFileName));
            string foto = "<img src='data:image/png;base64," + imageData + "' style='height:65px;width:90px;display:inline;'>";
            string paragraf = "   &nbsp;  &nbsp; &nbsp;  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Të dhënat për votuesit <br><br>";
            GridHtml = GridHtml.Replace("rekorde", " ").Replace("to", "deri").Replace("of", "nga").Replace("<!--IMG-->", foto + " " + paragraf).Replace("</style>", style + " </style>").Replace("Kërko:", " ").Replace("Showing", "Shfaqja e ").Replace("Shfaq", " ").Replace("të", " ").Replace("regjistruar", " ").Replace("10", " ").Replace("Kthehu1", " ").Replace("Vazhdo", " ");
            using MemoryStream stream = new();
            HtmlConverter.ConvertToPdf(GridHtml, stream);
            return File(stream.ToArray(), "application/pdf", "Performanca&Raporti.pdf");
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
                _logger.LogError("An error has occurred", err.Message);
                return View(errorView);
            }
        }
    }
}
