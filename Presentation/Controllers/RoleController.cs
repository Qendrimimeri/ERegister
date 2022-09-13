using Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RoleController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult AddRoles()
        {
            return View();
        }
        public IActionResult GetRoles()
        {
            return View();
        }

    }
}
