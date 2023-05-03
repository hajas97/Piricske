using Microsoft.EntityFrameworkCore;

namespace Piricske.Models
{
    public class ReservationContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.Id)
                .Property(r => r.CustomerName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
