using Microsoft.AspNetCore.Mvc;
using Piricske.Models;
using System.Diagnostics;


namespace Piricske.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            return RedirectToAction("Index", "Reservation");
        }

        public IActionResult Gallery()
        {
            return RedirectToAction("Index", "Gallery");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}