using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        //Arsye percaktuese general demand 
        [HttpPost]
        [Route("addgeneraldemand")]

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
            catch (Exception ex)
            {
                Log.Fatal(ex, "[Post]AddGeneralDemand terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

        }
        //ndihma nevojshme
        [HttpPost]
        [Route("GetNeedHelp")]
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
            catch(Exception ex)
            {
                Log.Fatal(ex, "[Post]GetNeedHelp terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return Ok();

        }
        public async Task<IActionResult> Voters(string name)
        {
            try
            {
                var vm = await _unitOfWork.ApplicationUser.GetVoterInfoAsync();
                if (vm == null)
                {
                    return NotFound();
                }
                var vm1 = vm.Where(c => c.FullName == name).FirstOrDefault();
                TempData["success"] = "Finded successfuly!";
                return PartialView("_Voters", vm1);
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]Voters terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return View();
        }

        public IActionResult Cancel()
        {
            TempData["success"] = "Closed!";
            return RedirectToAction("Index");
        }

        public async Task <IActionResult> SaveAndClose(PollRelated pollRelated)
        {
            try
            {
                _unitOfWork.PollRelated.Update(pollRelated);
                await _unitOfWork.Done();
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]SaveAndClose terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return RedirectToAction("Index", "Dashboard");

        }

        public async Task <IActionResult> SaveAndOpenCase(PollRelated pollRelated)
        {
            try
            {
                _unitOfWork.PollRelated.Update(pollRelated);
                await _unitOfWork.Done();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[GET]SaveAndOpenCase terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
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
