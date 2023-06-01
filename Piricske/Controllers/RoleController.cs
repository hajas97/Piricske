using Microsoft.AspNetCore.Mvc;

namespace Piricske.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
