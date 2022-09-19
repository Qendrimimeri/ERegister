 using Application.Repository;
using Microsoft.AspNet.Identity;
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
        public async Task<IActionResult> Performance() 
        {
            var users =  await _unitOfWork.ApplicationUser.GetPersonInfoAsync();
            return View(users); 
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
        public IActionResult BusinessUserProfile()
        {
            return View();
        }
    }
}
