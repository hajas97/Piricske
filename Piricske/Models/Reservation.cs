using System;

namespace Piricske.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration
        {
            get
            {
                return (DepartureDate - ArrivalDate).Days;
            }
        }
        public bool IsReserved { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}