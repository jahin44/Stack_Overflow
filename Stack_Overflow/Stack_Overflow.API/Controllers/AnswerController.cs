using Microsoft.AspNetCore.Mvc;

namespace Stack_Overflow.API.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
