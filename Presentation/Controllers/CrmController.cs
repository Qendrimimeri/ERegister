using Application.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
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
        public IActionResult GeneralReasons()
        {
            return View();
        }
        public IActionResult AddHelper()
        {
            return View();
        }
    }
}
