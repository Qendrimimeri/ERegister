using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AddressController : Controller
    {
    
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
