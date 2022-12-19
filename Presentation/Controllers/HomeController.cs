using Application.Models.Services;
using Application.Repository;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Roles _roles;


        public HomeController(IUnitOfWork unitOfWork,
                              ILogger<HomeController> logger,
                              IHttpContextAccessor httpContext,
                               IOptionsSnapshot<Roles> roles)
        {
            _logger = logger;
            _httpContext = httpContext;
            _unitOfWork = unitOfWork;
            _roles = roles.Value;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    var res = _httpContext.HttpContext.User.Identity;
                    if (await _unitOfWork.ApplicationUser.IsInSimpleRole(res.Name))
                    {
                        return RedirectToAction("AddVoter", "AddsAdmin");
                    }
                    return RedirectToAction("index", "Dashboard");
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginVM login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!(await _unitOfWork.ApplicationUser.IsEmailConfirmed(login)))
                    {
                        ViewBag.NotConfirmed = true;
                        return View("../home/index", login);
                    }
                    var zz = await _unitOfWork.ApplicationUser.CheckUser(login.Email, login.Password);
                    if (!(zz))
                    {
                        ViewBag.NotAuth = true;
                        return View("../home/index", login);
                    }
                    var roles = await _unitOfWork.ApplicationUser.GetRoles(login.Email);
                    bool isLogIn = false;
                    if (roles.Contains(_roles.AnetarIThjeshte))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                        {
                            TempData["success"] = "Jeni kyçur në  llogarinë tuaj!";
                            ViewBag.Login = true;
                            return RedirectToAction("AddVoter", "AddsAdmin");
                        }

                    }
                    else if (roles.Contains(_roles.KryetarIFshatit))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                        {
                            TempData["success"] = "Jeni kyçur në  llogarinë tuaj!";
                            isLogIn = true;
                            return RedirectToAction("Index", "Crm");

                        }
                    }
                    else if ((roles.Contains(_roles.KryetarIPartise)) || (roles.Contains(_roles.KryetarIKomunes)))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                        {
                            TempData["success"] = "Jeni kyçur në  llogarinë tuaj!";
                            ViewBag.Login = true;
                            isLogIn = true;
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                    if (!isLogIn)
                    {
                        ViewBag.NotAuth = true;
                        return View("../home/index", login);
                    }
                }
                return View("../Home/Index", login);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
                
        }


        [HttpGet]
        public  IActionResult Forgot(EmailVM model)
        {
            try
            {
                return View(model);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }

        [HttpGet]
        public IActionResult AboutUs()
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


        [HttpGet, Authorize]
        public IActionResult ChangePassword()
        {
            try
            {
                return View("changePassword");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordImmediatelyVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.ApplicationUser.ChangePasswordImmediately(model);
                    if (res.Succeeded) return RedirectToAction("Index", "Dashboard");
                    return View();
                }
                ViewBag.PassDoesntMatch = true;
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