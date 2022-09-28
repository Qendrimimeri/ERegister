using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Infrastructure.Services;

using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DashboardController(IUnitOfWork unitOfWork, 
                                  UserManager<ApplicationUser> userManager,
                                  IWebHostEnvironment env,
                                  SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _env = env;
           _signInManager = signInManager;
        }




      
        [Authorize(Roles = "SuperAdmin,MunicipalityAdmin,LocalAdmin")]

        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "SuperAdmin,MunicipalityAdmin,LocalAdmin")]
       
        public async Task<IActionResult> Performance() 
        {
            var users =  await _unitOfWork.ApplicationUser.GetPersonInfoAsync();
            return View(users); 
        }

        [HttpGet]
        public async Task<IActionResult> Reports(string id) 
        { 
            var users =  await _unitOfWork.ApplicationUser.GetUserByIdAsync(id);
            var PS = new SelectList(await _unitOfWork.PoliticalSubject.GetAll(), "Id", "Name");
            ViewBag.PS = PS;

            var successChances = new SelectList(StaticData.SuccessChances(), "Key", "Value");
            ViewBag.successChances = successChances;

            var actualStatus = new SelectList(StaticData.ActualStatus(), "Key", "Value");
            ViewBag.actualStatus = actualStatus;
            return View(users); 
        }

        [HttpPost]
        public async Task<IActionResult> Reports(PersonVM  editVoter)
        {

            if (ModelState.IsValid)
            {
                var users = await _unitOfWork.PollRelated.AddPollRelated(editVoter);

                return RedirectToAction("Performance", "Dashboard");
                


            }
            TempData["success"] = "U regjistrua me sukses!";

            return View();
        }


        public IActionResult AddSubject()
        {
            return View();
        }
      
        public IActionResult EditAdmin()
        {
            return View();
        }

        public IActionResult AddVoter()
        {
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult KqzResult()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BusinessUserProfile()
        {
            var res = await _userManager.GetUserAsync(User);
            var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Email);

            return View(user);
        }

        [HttpPost]
        public async  Task<IActionResult> BusinessUserProfile(ProfileVM editUser)
         {
            if (ModelState.IsValid)
            {
                if (editUser.Image == null)
                {
                    var result = await _unitOfWork.ApplicationUser.EditUserProfile(editUser);
                    if (result)
                    {
                        var res = _userManager.GetUserAsync(User);
                        var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Result.Email);
                        return View(user);
                    }

                }
               else if (editUser.Image!= null)
                {
                    var rootFilePath = _env.WebRootPath;
                    string filePath = Path.Combine(rootFilePath, "Document");
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    var fileName = $"{Guid.NewGuid()}_{editUser.Image.FileName}";

                    var fullPath = Path.Combine(filePath, fileName);

                    using (var fileStream = new FileStream( fullPath, FileMode.Create))
                        editUser.Image.CopyTo(fileStream);
                    var result = await _unitOfWork.ApplicationUser.EditProfileDetails(editUser, fileName);
                    if (result)
                    {
                        var res = _userManager.GetUserAsync(User);
                        var user = await _unitOfWork.ApplicationUser.GetProfileDetails(res.Result.Email);
                        return View(user);
                    }
                }
            }
            return View();
        }
        [HttpGet]
         public IActionResult ChangePassWord()
        {
            return View();
        }

        public async Task<IActionResult>ChangePassword(ChangePasswordVM model)
        {
            if(ModelState.IsValid)
            { 
                var user= await _userManager.GetUserAsync(User);
                if(user== null)
                {
                    return RedirectToAction("Index","Home");
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    TempData["Success"] = "Fjalekalimi i ndryshua me sukses!";
                    return View();
                    
                }
                
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("BusinessUserProfile");
               
            }
            return View(model);
          
        }

    }
}
