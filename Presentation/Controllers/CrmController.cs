﻿using Application.Repository;
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
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                return View();
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
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");

                var vm = await _unitOfWork.ApplicationUser.GetVoterInfoAsync();

                var vm1 = vm.Where(c => c.FullName == name).FirstOrDefault();
                if (vm1 == null)
                {
                    ViewBag.Name = name;
                    ViewBag.UserNull = "Nuk ka te dhena";
                }
                return PartialView("_Voters", vm1);
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Voters(VoterDetailsVM model)
        {
            try
            {
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");

                TempData["success"] = "U ruajt me sukses!";
                return RedirectToAction("Index");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }



      public IActionResult AutoComplete(string prefix, int id)
        {
            try
            {
                var users = (from a in this._context.ApplicationUsers
                             from c in this._context.Addresses
                             from b in this._context.UserRoles.Where(x =>  x.RoleId == "04445284-5327-4e00-9014-8385ac639412"
                                                                           && a.FullName.StartsWith(prefix)
                                                                           && a.Id == x.UserId 
                                                                           && c.Id == a.AddressId
                                                                           && c.MunicipalityId == id
                                                                           )
                             select new
                             {
                                 label = a.FullName,
                                 val = a.Id
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


        public async Task<IActionResult> SaveAndClose(VoterDetailsVM model)
        {
            try
            {
                var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
                ViewBag.ArysjetPercaktues = new SelectList(StaticData.GeneralReason(), "Key", "Value");
                ViewBag.NdihmaNevojshme = new SelectList(StaticData.GeneralDemands(), "Key", "Value");
                ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");

                TempData["success"] = "U ruajt me sukses!";
                return RedirectToAction("Index","Dashboard");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured", err);
                return View(errorView);
            }
        }


        public async Task<IActionResult> SaveAndOpenCase(PollRelated pollRelated)
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


        #region API CALL

        //public async Task<bool> GeneralDemand([FromQuery] string reason, string userId)
        //{
        //    var res = await _unitOfWork.PollRelated.updateSpecificReasonAsync(reason, userId);
        //    return true;
        //}
        public async Task<bool> SpecificDemand([FromQuery] string reason, string userId)
        {
            var res = await _unitOfWork.PollRelated.updateSpecificDemandAsync(reason, userId);
            return true;
        }
        #endregion
    }
}
