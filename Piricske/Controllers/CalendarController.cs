using Microsoft.AspNetCore.Mvc;

public class BookingController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult Index()
    {
        var bookings = db.Bookings.ToList();
        return View(bookings);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Reservation booking)
    {
        if (ModelState.IsValid)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(booking);
    }
}