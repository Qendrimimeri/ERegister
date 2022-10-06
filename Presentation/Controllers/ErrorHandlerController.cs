using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class ErrorHandlerController : Controller
    {
        [Route("/ErrorHandler/Error/{code:int}")]
        public IActionResult Error(int code)
            => View( "../Error/Error", 
                   ( new ErrorModel { ErrorMessage = $"Error Occurred. Error Code is{code}" }));
    }
}
