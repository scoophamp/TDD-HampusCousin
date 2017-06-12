using System;

namespace TravelAgencyES4
{
    public class Booking
    {
        public Passenger passenger { get; set; }
        public string TourName { get; set; }
        public int Seats { get; set; }
        public DateTime DateOfTour { get; set; }
    }
}