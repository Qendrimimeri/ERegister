using Application.Repository;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork) =>  _unitOfWork = unitOfWork;


        [HttpGet]
        public IActionResult Index() => View();


        [HttpGet]
        public  IActionResult Forgot(EmailVM model) => View(model);


        [HttpGet]
        public IActionResult AboutUs() => View();
    }

    
}