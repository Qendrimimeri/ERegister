using Application.Repository;
using Application.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AddressController : Controller
    {
      
        private readonly IUnitOfWork _unitOfWork;

        public AddressController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
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
    }
}
