using Application.Repository;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(IUnitOfWork unitOfWork,
                              ILogger<HomeController> logger,
                              IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _httpContext = httpContext;
            _unitOfWork = unitOfWork;   
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
                    return RedirectToAction("index", "Dashboard");
                return View();
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
    }

    
}