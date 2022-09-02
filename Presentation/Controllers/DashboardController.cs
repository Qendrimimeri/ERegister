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

        public IActionResult Block()
        {
            return View();
        }

        public IActionResult AddBlock()
        {
            return View();
        }

        public IActionResult Performance() 
        { 
            return View(); 
        }


        public IActionResult Street()
        {
            return View();
        }

        public IActionResult AddStreet()
        {
            return View();
        }

        public IActionResult Neighborhood()
        {
            return View();
        }

        public IActionResult AddNeighborhood() { return View(); }
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


        public IActionResult Houses()
        {
            return View();
        }

        public IActionResult AddHouses()
        {
            return View();
        }

        public IActionResult AddVoter()
        {
            return View();
        }
        public IActionResult AddSubject()
        {
            return View();
        }
        public IActionResult AddHelper()
        {
            return View();
        }
        public IActionResult EditHelper()
        {
            return View();
        }




    }
}
