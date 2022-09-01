using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crm()
        {
            return View();
        }
       public IActionResult AddRole()
        {
            return View();
        }
        public IActionResult AllRoles()
        {
            return View();
        }
        public IActionResult Performance() { return View(); }
        public IActionResult Reports() { return View(); }
        public IActionResult ArsyejaPercaktuese()
        {
            return View();
        }
        public IActionResult ArsyetEPercaktuara()
        {
          return View();
        }
        public IActionResult AddsAdmin()
        {
            return View();
        }
        public IActionResult EditAdmin()
        {
            return View();
        }

    }
}
