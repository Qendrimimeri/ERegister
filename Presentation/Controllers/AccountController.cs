﻿using Application.Models.Services;
using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Presentation.Controllers
{
#pragma warning disable CS8604

    public class AccountController : Controller
    {
        private readonly string errorView = "../Error/ErrorInfo";
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly Toaster _toaster;
        private readonly Roles _roles;

        public AccountController(IUnitOfWork unitOfWork,
                                  SignInManager<ApplicationUser> signInManager,
                                  ILogger<AccountController> logger,
                                  IOptionsSnapshot<Roles> roles,
                                  IOptionsSnapshot<Toaster> toaster)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _logger = logger;
            _toaster = toaster.Value;
            _roles = roles.Value;
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            try
            {
                var hasEmail = _unitOfWork.ApplicationUser.GetEmail(login.Email);

                if (!hasEmail)
                {
                    ViewBag.Email = login;
                    ViewBag.EmailNull = hasEmail;
                }


                else if (ModelState.IsValid)
                {
                    // get the role of the signin user 
                    var roles = (await _unitOfWork.ApplicationUser.GetRoles(login.Email));

                    if (roles.Contains(_roles.AnetarIThjeshte))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                            TempData["success"] = "Jeni kyqur ne llogarinë tuaj";
                        return RedirectToAction("AddVoter", "AddsAdmin");
                    }
                    else if (roles.Contains(_roles.KryetarIFshatit))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                            TempData["success"] = "Jeni kyqur ne llogarinë tuaj";

                        return RedirectToAction("Index", "Crm");
                    }
                    else if ((roles.Contains(_roles.KryetarIPartise)) || (roles.Contains(_roles.KryetarIKomunes)))
                    {
                        if (await _unitOfWork.ApplicationUser.LoginAsync(login))
                            TempData["success"] = "Jeni kyqur ne llogarinë tuaj";

                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                // ModelState.AddModelError("", "Kreencialet e gabuara");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception err)
            {
                _logger.LogError(message: "An error has occurred ", err);
                return View(errorView);
            }
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            try
            {
                return View("../Account/AccessDenied");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }



        [HttpGet]
        public IActionResult ConfirmedEmail()
        {
            try
            {
                return View("ConfirmEmail");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occurred", err);
                return View(errorView);
            }
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            try
            {
                if (userId == null || token == null)
                {
                    ModelState.AddModelError(string.Empty, "Id e perdoruesit ose Tokeni nuk jane valid.");
                    return View();
                }
                var userIdentity = await _unitOfWork.ApplicationUser.FindUserByIdAsync(userId);
                var result = await _unitOfWork.ApplicationUser.ConfirmEmailAsync(userIdentity, token.Replace(" ", "+"));

                if (result.Succeeded)
                    return RedirectToAction("ConfirmedEmail");
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An Error has occured", err);
                return View(errorView);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(EmailVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    await _unitOfWork.ApplicationUser.ForgotPasswordAsync(model.Email);

                    model.IsEmailSent = true;
                    return RedirectToAction("forgot", "home", model);
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured in Forgot password ", err);
                return View(errorView);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            try
            {
                if (userId == null && token == null)
                    return View("ResetPasswordError");

                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured in Reset Password", err);
                return View(errorView);
            }
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string replaceToken = model.Token.Replace(" ", "+");
                    model.Token = replaceToken;

                    var res = await _unitOfWork.ApplicationUser.ResetPasswordAsync(model);
                    if (res.Succeeded)
                    {
                        TempData["success"] = "Jeni kyçur në llogarinë tuaj";
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured in {Reset Password} method", err);
                return View(errorView);
            }
        }


        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                TempData[_toaster.Success] = "Jeni shkyqur nga llogaria juaj!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception err)
            {
                _logger.LogError("An error has occured in {Logout}", err);
                return View(errorView);
            }
        }
    }

#pragma warning restore CS8604
}
