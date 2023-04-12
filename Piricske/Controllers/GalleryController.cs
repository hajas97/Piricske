using Microsoft.AspNetCore.Mvc;

namespace Piricske.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
