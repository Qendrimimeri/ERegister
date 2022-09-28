﻿using Application.ViewModels;
using Application.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNet.Identity;
using Domain.Data.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Serilog;

namespace Presentation.Controllers
{


    public class AddsAdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContext;

        public AddsAdminController( IUnitOfWork unitOfWork ,IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _httpContext = httpContext;
        }

        public async Task<IActionResult> AddVoter()
        {
            try
            {
                var res = _httpContext.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier);
                //PS ==> Political Subjects
                var PS = new SelectList(await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
                ViewBag.PS = PS;

                var municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
                ViewBag.municipalities = municipalities;

                var villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
                ViewBag.villages = villages;

                var neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
                ViewBag.neigborhoods = neigborhoods;

                var pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
                ViewBag.pollCenters = pollCenters;

                var blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
                ViewBag.blocks = blocks;

                var streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
                ViewBag.streets = streets;

                var administrativeUnits = new SelectList(StaticData.AdministrativeUnits(), "Key", "Value");
                ViewBag.administrativeUnits = administrativeUnits;

                var successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
                ViewBag.successChances = successChances;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]AddVoter terminated unexpectedly");

            }
            finally {Log.CloseAndFlush();} 

            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.Account.RegisterVoterAsync(register);
                    if (res)
                    {
                        return RedirectToAction("Index", "dashboard");
                    }
                }
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[POST]Register terminated unexpectedly");

            }
            finally { Log.CloseAndFlush();}

            return RedirectToAction("AddVoter");
        }


        [Authorize(Roles = "SuperAdmin,MunicipalityAdmin,LocalAdmin")]
        public async Task<IActionResult> PoliticalOffical()
        {
            try
            {
                var municipalities = new SelectList(await _unitOfWork.Municipality.GetAll(), "Id", "Name");
                ViewBag.municipalities = municipalities;

                var villages = new SelectList(await _unitOfWork.Village.GetAll(), "Id", "Name");
                ViewBag.villages = villages;

                var neigborhoods = new SelectList(await _unitOfWork.Neighborhood.GetAll(), "Id", "Name");
                ViewBag.neigborhoods = neigborhoods;

                var pollCenters = new SelectList(await _unitOfWork.PollCenter.GetAll(), "Id", "CenterNumber");
                ViewBag.pollCenters = pollCenters;

                var blocks = new SelectList(await _unitOfWork.Block.GetAll(), "Id", "Name");
                ViewBag.blocks = blocks;

                var streets = new SelectList(await _unitOfWork.Street.GetAll(), "Id", "Name");
                ViewBag.streets = streets;

                var roles = new SelectList(await _unitOfWork.ApplicationUser.GetAllRolesAsync(), "Key", "Value");
                ViewBag.roles = roles;

                return View();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[GET]PoliticalOffical terminated unexpectedly");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            return View();

        }

        [HttpPost()]
        public async Task<IActionResult> PoliticalOffical(PoliticalOfficalVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await _unitOfWork.Account.AddPoliticalOfficialAsync(model);
                    if (res)
                        return RedirectToAction("Index", "Dashboard");
                }
                return View();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "[POST]PoliticalOffical terminated unexpectedly");

            }
            finally { Log.CloseAndFlush(); }
            return View();

        }




















        public IActionResult AddPoliticalSubject()
        {

            return View();
        }

        public IActionResult AddBlock()
        {
            return View();
        }
        public IActionResult AddStreet()
        {
            return View();
        }
        public IActionResult AddNeighborhood()
        {
            return View();
        }
        public IActionResult EditPoliticalSubjectTest()
        {
            return View();
        }
        public IActionResult AddPoliticalSubjectTest()
        {
            return View();
        }
    }
}
