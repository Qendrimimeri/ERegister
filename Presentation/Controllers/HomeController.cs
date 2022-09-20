using Application.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IActionResult Index() => View();

        [HttpGet]
        public  IActionResult Forgot() => View();

        public IActionResult AboutUs() => View();
    }

    
}