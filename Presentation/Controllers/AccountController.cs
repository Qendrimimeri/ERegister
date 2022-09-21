﻿using Application.Models;
using Application.Repository;
using Application.ViewModels;
using Domain.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        
        public IAccountRepository AccountRepository { get; }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var res = await _unitOfWork.Account.LoginAsync(login);
                if (res == true)
                    return RedirectToAction("Index", "Dashboard");
                //returnUrl = returnUrl ?? Url.Content("~/Dashboard/index");
                //return LocalRedirect(returnUrl);
                // ModelState.AddModelError("", "Login failed, wrong credentials");
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login failed, wrong credentials");


            return RedirectToAction("Index", "Home", ModelState);
        }
        public IActionResult AccessDenied()
        {
            return View("../Account/AccessDenied");
        }

        [Route("/Account/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            return View(new ErrorModel {ErrorMessage = $"Error Occurred. Error Code is{code}" });
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
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

        public async Task<IActionResult> ConfirmedEmail() => View("ConfirmEmail");




        [HttpPost]
        public async Task<IActionResult> ForgotPassword(EmailVM model)
        {
            if (ModelState.IsValid)
            {
                var res = await _unitOfWork.Account.ForgotPasswordAsync(model.Email);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (userId == null && token == null)
                return View("ResetPasswordError");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                string replaceToken = model.Token.Replace(" ", "+");
                model.Token = replaceToken;

                var res = await _unitOfWork.Account.ResetPasswordAsync(model);
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
