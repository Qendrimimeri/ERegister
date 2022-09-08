using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AddsAdminController : Controller
    {
        public IActionResult AddVoter()
        {
            return View();
        }

       public IActionResult AddPoliticalSubject()
       {
           return View();
       }


        public IActionResult EditPoliticalSubject()
        {
            return View();
        }

        public IActionResult AddBlock()
        {
            return View();
        }
        public IActionResult AddStreet()
        {
            return View();
        }
        public IActionResult AddNeighborhood()
        {
            return View();
        }
        public IActionResult EditPoliticalSubjectTest()
        {
            return View();
        }
        public IActionResult AddPoliticalSubjectTest()
        {
            return View();
        }
    }
}
