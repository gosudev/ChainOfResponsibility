using System;

namespace ChainOfResponsibility.Models
{
    public class ApartmentBooking
    {
        public int Id { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}