using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public  IActionResult Forgot() => View();

        public IActionResult AboutUs() => View();
    }

    
}