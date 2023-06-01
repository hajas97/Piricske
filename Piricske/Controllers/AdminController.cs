using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Piricske.Data;
using Piricske.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piricske.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ReservationContext _reservationContext;

        public AdminController(UserManager<IdentityUser> userManager, ReservationContext reservationContext)
        {
            _userManager = userManager;
            _reservationContext = reservationContext;
        }

        // Összes foglalás lekérése
        public IActionResult Index()
        {
            var reservations = _reservationContext.Reservations;
            return View(reservations);
        }

        // Foglalás törlése
        public async Task<IActionResult> Delete(int Id)
        {
            var reservation = await _reservationContext.FindAsync<Reservation>(Id);
            if (reservation != null)
            {
                _reservationContext.Remove(reservation);
                await _reservationContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // Foglalás módosítása
        public async Task<IActionResult> EditAsync(int Id)
        {
            var reservation = await _reservationContext.FindAsync<Reservation>(Id);
            if (reservation != null)
            {
                // Módosítás végrehajtása
                // ...
            }

            return RedirectToAction("Index");
        }

    }
}

