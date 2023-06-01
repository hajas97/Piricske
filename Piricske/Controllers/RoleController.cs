using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Piricske.Models;
using System.Threading.Tasks;

namespace Piricske.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // Admin szerep létrehozása
        public async Task<IActionResult> CreateAdminRole()
        {
            var roleExists = await _roleManager.RoleExistsAsync(UserRole.Admin);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
