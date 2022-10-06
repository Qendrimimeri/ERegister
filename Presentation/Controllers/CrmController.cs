using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers

{
    [Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]

    public class CrmController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public CrmController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
          _unitOfWork = unitOfWork;
            _context=context;
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
                SpecificReason = model.SpecificReason
            });

            _unitOfWork.SaveChanges();

            return Ok();
        }
        //ndihma nevojshme
        [HttpPost]
        [Route("GetNeedHelp")]
        public ActionResult GetNeedHelp([FromBody] GeneralDemandVM model)
        {
            _unitOfWork.PollRelated.Add(new PollRelated
            {
                SpecificDemand = model.SpecificDemand
            });

            _unitOfWork.SaveChanges();

            return Ok();
        }
        public async Task<IActionResult> Voters(string name)
        {
            ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
            ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");

            var vm = await _unitOfWork.ApplicationUser.GetVoterInfoAsync();
           
            var vm1 = vm.Where(c => c.FullName == name).FirstOrDefault(); 
            if (vm1 == null)
            {
                return BadRequest();

            }
            return PartialView("_Voters" ,vm1);
        }
        public JsonResult AutoComplete(string prefix)
        {
            var customers = (from movie in this._context.ApplicationUsers
                             where movie.FullName.StartsWith(prefix)
                             select new
                             {
                                 label = movie.FullName,
                                 val = movie.Id
                             }).ToList();

            return Json(customers);
        }

        public IActionResult Cancel()
        {
            TempData["success"] = "U anulua!";
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> SaveAndClose(PollRelated pollRelated)
        {
             _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            TempData["success"] = "U ruajt me sukses!";
            return RedirectToAction("Index","Dashboard");
        }

        public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            _unitOfWork.PollRelated.Update(pollRelated);
            await _unitOfWork.Done();
            TempData["success"] = "U ruajt me sukses!";
            return RedirectToAction("Index");
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
