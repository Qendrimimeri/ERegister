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
        public IActionResult ArsyejaPercaktuese()
        {
            return View();
        }
        public IActionResult ArsyetEPercaktuara()
        {
            return View();
        }

    }
}
