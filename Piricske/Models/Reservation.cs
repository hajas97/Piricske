using System;
using System.ComponentModel.DataAnnotations;

namespace Piricske.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        [Display(Name = "Érkezés időpontja")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Távozás időpontja")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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