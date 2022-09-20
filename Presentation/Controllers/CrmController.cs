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

        [HttpPost]
        public async Task<IActionResult> Voters(string name)
        {
            var users = new List<PollRelated>();
            var vm = await _unitOfWork.PollRelated.GetAll();
            if (vm == null)
            {
                return NotFound();
            }
            users = vm.Where(c => c.ApplicationUsers.FullName == name).ToList();
            VoterDetailsVM vm1 = new VoterDetailsVM();
            return PartialView("_Voters" , users);
        }
        

        [HttpPost]
        public IActionResult Cancel()
        {
            return View("Index" , "Dashboard");
        }

        [HttpPost]
        public async Task <IActionResult> SaveAndClose(PollRelated pollRelated)
        {
             _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            return RedirectToAction("Index", "Dashboard");
        }
        public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            return RedirectToAction("Index", "Crm");
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
