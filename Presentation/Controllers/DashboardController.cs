using Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
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
      
        public IActionResult EditAdmin()
        {
            return View();
        }

        public IActionResult AddVoter()
        {
            return View();
        }
        public IActionResult KqzResult()
        {
            return View();
        }
    }
}
