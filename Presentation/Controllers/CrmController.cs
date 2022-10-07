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
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CrmController> _logger;

        public CrmController(IUnitOfWork unitOfWork,
                             ILogger<CrmController> logger,
                             ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context=context;
        }


        [HttpGet]
        public IActionResult Index() =>  View();


        //Arsye percaktuese general demand 
        [HttpPost, Route("addgeneraldemand")]
        public ActionResult AddGeneralDemand([FromBody] GeneralDemandVM model)
        {
            try
            {
                _unitOfWork.PollRelated.Add(new PollRelated
                {
                    SpecificReason = model.SpecificReason
                });
                _unitOfWork.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured ", err);
                return View(errorView);
            }

        }


        //ndihma nevojshme
        [HttpPost, Route("GetNeedHelp")]
        public ActionResult GetNeedHelp([FromBody] GeneralDemandVM model)
        {
            try
            {
                _unitOfWork.PollRelated.Add(new PollRelated
                {
                    SpecificDemand = model.SpecificDemand
                });
                _unitOfWork.SaveChanges();

                return Ok();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }

        }


        public async Task<IActionResult> Voters(string name)
        {
            try
            {
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");

                var vm = await _unitOfWork.ApplicationUser.GetVoterInfoAsync();

                var vm1 = vm.Where(c => c.FullName == name).FirstOrDefault();
                if (vm1 == null)
                {
                    return BadRequest();

                }
                return PartialView("_Voters", vm1);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public IActionResult AutoComplete(string prefix)
        {
            try
            {
                var users = (from user in this._context.ApplicationUsers
                             where user.FullName.StartsWith(prefix)
                             select new
                             {
                                 label = user.FullName,
                                 val = user.Id
                             }).ToList();

                return Json(users);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return BadRequest();
            }

        }

        public IActionResult Cancel()
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }

        }


        public async Task <IActionResult> SaveAndClose(PollRelated pollRelated)
        {
            try
            {
                _unitOfWork.PollRelated.Update(pollRelated);
                await _unitOfWork.Done();
                TempData["success"] = "U ruajt me sukses!";
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            try
            {
                _unitOfWork.PollRelated.Update(pollRelated);
                await _unitOfWork.Done();
                TempData["success"] = "U ruajt me sukses!";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public IActionResult GeneralReasons() => View();


        public IActionResult AddHelper() => View();


        public IActionResult OpenCases() => View();
    }
}
