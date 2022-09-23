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
        //Arsye percaktuese general demand 
        [HttpPost]
        [Route("addgeneraldemand")]
        public ActionResult AddGeneralDemand([FromBody] GeneralDemandVM model)
        {
            _unitOfWork.PollRelated.Add(new PollRelated
            {
                GeneralDemand = model.GeneralDemand
            });

            _unitOfWork.SaveChanges();

            return Ok();
        }
        //ndihma nevojshme
        [HttpPost]
        [Route("addhelp")]
        public ActionResult GetNeedHelp([FromBody] NeedHelpVM model)
        {
            _unitOfWork.Help.Add(new Help
            {
                NeedHelp = model.NeedHelp
            });

            _unitOfWork.SaveChanges();

            return Ok();
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
