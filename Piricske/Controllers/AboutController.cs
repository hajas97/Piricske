using Microsoft.AspNetCore.Mvc;

namespace Piricske.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
