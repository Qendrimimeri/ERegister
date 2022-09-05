using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Performance() 
        { 
            return View(); 
        }
        public IActionResult Reports() 
        { 
            return View(); 
        }
        public IActionResult AddSubject()
        {
            return View();
        }
      
    }
}
