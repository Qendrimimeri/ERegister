using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult AddRole()
        {
            return View();
        }
        public IActionResult GetRoles()
        {
            return View();
        }

    }
}
