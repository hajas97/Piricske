using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Piricske.Data;
using Piricske.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Piricske.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationContext _context;

        public ReservationController(ReservationContext context)
        {
            _context = context;
        }

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return View(reservations);
        }

        // GET: Reservation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,ArrivalDate,DepartureDate,Email,Phone")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                // Ellenőrizzük, hogy az érkezési időpont nem múltbeli időpont-e
                if (reservation.ArrivalDate < DateTime.Now)
                {
                    ModelState.AddModelError("ArrivalDate", "Az érkezési időpont nem lehet múltbeli időpont!");
                    return View(reservation);
                }

                // Ellenőrizzük, hogy a foglalás az aktuális időponttól számított maximum 2 éven belül van-e
                DateTime twoYearsFromNow = DateTime.Now.AddYears(2);
                if (reservation.ArrivalDate > twoYearsFromNow)
                {
                    ModelState.AddModelError("ArrivalDate", "A foglalás csak az aktuális dátumtól számított maximum 2 éven belül lehetséges!");
                    return View(reservation);
                }

                if (reservation.DepartureDate < DateTime.Now)
                {
                    ModelState.AddModelError("DepartureDate", "A távozás időpontja nem lehet múltbéli időpont!");
                    return View(reservation);
                }

                reservation.IsReserved = true;
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }


        // GET: Reservation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,ArrivalDate,DepartureDate,Email,Phone,IsReserved")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Ellenőrizzük, hogy a távozás időpontja nem lehet múltbeli időpont
                if (reservation.DepartureDate < DateTime.Now.Date)
                {
                    ModelState.AddModelError("DepartureDate", "A távozás időpontja nem lehet múltbeli időpont!");
                    return View(reservation);
                }

                // Ellenőrizzük, hogy a foglalás csak az aktuális dátumtól számított maximum 2 hónapig módosítható
                DateTime twoMonthsFromNow = DateTime.Now.Date.AddMonths(2);
                if (reservation.ArrivalDate > twoMonthsFromNow)
                {
                    ModelState.AddModelError("ArrivalDate", "A foglalás csak az aktuális dátumtól számított maximum 2 hónapig módosítható!");
                    return View(reservation);
                }

                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reservation);
        }


        // GET: Reservation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }
    }
}
