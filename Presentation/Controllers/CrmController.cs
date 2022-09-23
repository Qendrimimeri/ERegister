using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CrmController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrmController(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Voters(string name)
        {
            var vm = await _unitOfWork.ApplicationUser.GetVoterInfoAsync();
            if (vm == null)
            {
                return NotFound();
            }
            var vm1 = vm.Where(c => c.FullName == name).FirstOrDefault();
            return PartialView("_Voters" ,vm1);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index","Dashboard");
        }

        public async Task <IActionResult> SaveAndClose(ApplicationUser user)
        {
             _unitOfWork.ApplicationUser.UpdateUserAsync(user);
            await _unitOfWork.Done();
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<IActionResult> SaveAndOpenCase(ApplicationUser user)
        {
            _unitOfWork.ApplicationUser.UpdateUserAsync(user);
            await _unitOfWork.Done();
            return View("Index");
        }
       
        public IActionResult GeneralReasons()
        {
            return View();
        }

        public IActionResult AddHelper()
        {
            return View();
        }
        public IActionResult OpenCases()
        {
            return View();
        }
    }
}
