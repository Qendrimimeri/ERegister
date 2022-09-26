using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers

{
    [Authorize(Roles = "SuperAdmin,MunicipalityAdmin,LocalAdmin")]

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
            TempData["success"] = "Finded successfuly!";
            return PartialView("_Voters" ,vm1);
        }
        
        public IActionResult Cancel()
        {
            TempData["success"] = "Closed!";
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> SaveAndClose(PollRelated pollRelated)
        {
             _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            return RedirectToAction("Index","Dashboard");
        }

        public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            return RedirectToAction("Index");
        }
        //public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        //{
        //    _unitOfWork.PollRelated.Update(pollRelated);
        //    await _unitOfWork.Done();

        //    return RedirectToAction("Index" , "Crm");
        //}
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
