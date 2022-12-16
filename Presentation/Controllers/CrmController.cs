using Application.Models.Services;
using Application.Repository;
using Application.ViewModels;
using Domain.Data;
using Domain.Data.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace Presentation.Controllers;


[Authorize(Roles = "KryetarIPartise,KryetarIKomunes,KryetarIFshatit")]
public class CrmController : Controller
{
    private readonly string errorView = "../Error/ErrorInfo";
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;
    private readonly Toaster _toaster;
    private readonly ILogger<CrmController> _logger;

    public CrmController(IUnitOfWork unitOfWork,
                         ILogger<CrmController> logger,
                         ApplicationDbContext context,
                         IOptionsSnapshot<Toaster> toaster)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _context = context;
        _toaster = toaster.Value;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            ViewBag.HasPasswordChange = await _unitOfWork.ApplicationUser.HasPasswordChange();
            ViewBag.SaveAndOpenCaseCRM = TempData["SaveAndOpenCaseCRM"] as string;
            ViewBag.mssg = TempData["mssg"] as string;
            ViewBag.SaveAndCloseCRMVillage = TempData["SaveAndCloseCRMVillage"] as string;
            ViewBag.mssgVillage = TempData["mssgVillage"] as string; 
            ViewBag.SaveAndCloseCRMVillage = TempData["AddPoliticalSaveAndCloseVillage"] as string;


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
            var result = name[..name.IndexOf("-")];
            Data();
            if (await _unitOfWork.ApplicationUser.GetVoterInfoAsync(result.Trim()) == null)
            {
                ViewBag.Name = name;
                ViewBag.UserNull = "nuk ka te dhena";
            }
            var res = await _unitOfWork.ApplicationUser.GetVoterInfoAsync(result.Trim());

            return PartialView("_Voters", res);
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
            var userId = _unitOfWork.ApplicationUser.GetLoginUser();
            var userInRoleKryetarIFshatit = await _unitOfWork.ApplicationUser.IsInRoleKryetarIFshatit(userId);
            var res = await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
            ViewBag.ArysjetPercaktues = new SelectList(StaticData.Reasons(), "Key", "Value");
            ViewBag.NdihmaNevojshme = new SelectList(StaticData.Demands(), "Key", "Value");
            ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");
            TempData["SaveAndCloseCRM"] = "U regjistruan me sukses!";

            if (userInRoleKryetarIFshatit)
            {
                TempData["SaveAndCloseCRMVillage"] = "U regjistruan me sukses!";
                return RedirectToAction("Index", "Crm");
            }
            
            return RedirectToAction("Index", "dashboard");
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occured", err);
            return View(errorView);
        }
    }



    public async Task<IActionResult> AutoComplete(string prefix, int id, string role)
    {
        try
        {

            if (role == "KryetarIPartise")
            {

                var users = (from a in _context.Voters.Where(x =>  x.FullName.Contains(prefix))

                             select new
                             {
                                 label = $"{a.FullName} - Komuna: {a.Address.Municipality.Name}",
                                 val = a.Id,
                             }).ToList();

                return Json(users);

            }
            else
            {
                var res = await _unitOfWork.ApplicationUser.GetVotersSuggest(prefix, id);
                return Json(res);
            }




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

    public async Task<IActionResult> SaveAndOpenCase(VoterDetailsVM model)
    {
        try
        {
                Data();
                await _unitOfWork.PollRelated.UpdateCrmRelatedAsync(model);
            TempData["SaveAndOpenCaseCRM"] = "U regjistruan me sukses!";
            return RedirectToAction("Index", "Crm");
        }
        catch (Exception err)
        {
            _logger.LogError("An error has occured", err);
            return View(errorView);
        }
    }


    #region ViewBag Data

    private void Data()
    {
        ViewBag.ArysjetPercaktues = new SelectList(StaticData.Reasons(), "Key", "Value");
        ViewBag.NdihmaNevojshme = new SelectList(StaticData.Demands(), "Key", "Value");
        ViewBag.YesNo = new SelectList(StaticData.YesNo(), "Key", "Value");
        ViewBag.PS = new SelectList(StaticData.PoliticalSubjects().OrderBy(x => x.Value), "Key", "Value");
        ViewBag.successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
        ViewBag.actualStatus = new SelectList(StaticData.ActualStatus(), "Key", "Value");
    }

    #endregion
}
