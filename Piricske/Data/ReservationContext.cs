using Microsoft.EntityFrameworkCore;
using Piricske.Models;

namespace Piricske.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}