using Application.Repository;
using Application.ViewModels;
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

        public async Task<IActionResult> Voters(string name)
        {
            List<VoterDetailsVM> vm = new List<VoterDetailsVM>();
            VoterDetailsVM vm1= new VoterDetailsVM();
            vm1.FirstName = "asassa";
            vm.Add(vm1);

            return PartialView("_Voters",vm1);
        }
        //public JsonResult GetSearchingData(string name , string searchValue)

       


        public IActionResult GeneralReasons()
        {
            return View();
        }
        public IActionResult AddHelper()
        {
            return View();
        }
        public IActionResult OpenCases()
        {
            return View();
        }
    }
}
