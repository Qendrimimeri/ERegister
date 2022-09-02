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
        public IActionResult AddVoter()
        {
            return View();
        }
        public IActionResult AddSubject()
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

        public IActionResult AddNeighborhood()
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
    }
}
