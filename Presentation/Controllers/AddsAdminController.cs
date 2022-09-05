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
    }
}
