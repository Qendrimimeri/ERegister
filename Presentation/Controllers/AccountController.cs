using Application.Repository;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController( IUnitOfWork unitOfWork )
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
    }
}
