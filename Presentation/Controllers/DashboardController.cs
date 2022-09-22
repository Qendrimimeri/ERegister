using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IUnitOfWork unitOfWork ,UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Reports(PersonVM  editVoter)
        {

            if (ModelState.IsValid)
            {
                var users = await _unitOfWork.PollRelated.AddPollRelated(editVoter);
                return RedirectToAction("Performance", "Dashboard");
            }
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

        [HttpGet]
        public async Task<IActionResult> BusinessUserProfile()
        {
            var res =_userManager.GetUserAsync(User);
            var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Result.Email);

            return View(user);
        }

        [HttpPost]
        public async  Task<IActionResult> BusinessUserProfile(ProfileVM editUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.ApplicationUser.EditProfileDetails(editUser);
                if (result)
                {
                    var res = _userManager.GetUserAsync(User);
                    var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Result.Email);
                    return View(user);
                }
            }
            return View();
        }



    }
}
