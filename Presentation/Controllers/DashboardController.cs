
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> Reports(string id) 
        { 
            var users =  await _unitOfWork.ApplicationUser.GetUserByIdAsync(id);
            var PS = new SelectList(await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.PS = PS;

            var successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
            ViewBag.successChances = successChances;

            var actualStatus = new SelectList(StaticData.ActualStatus(), "Key", "Value");
            ViewBag.actualStatus = actualStatus;

            return View(users); 
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
