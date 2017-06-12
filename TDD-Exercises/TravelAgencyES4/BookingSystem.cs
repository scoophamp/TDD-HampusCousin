using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgencyES4;

namespace TravelAgencyES4
{
    public class BookingSystem
    {
        private List<Booking> bookings { get; set; } = new List<Booking>();
        private ITourSchedule tourSchedule;
        public BookingSystem(ITourSchedule iTourSchedule)
        {
            tourSchedule = iTourSchedule;
        }

        public void CreateBooking(string tourName, DateTime dateOfTour, int seats, Passenger stubPassenger)
        {
            var tour = tourSchedule.listOfTours.FirstOrDefault(x => x.NameOfTour == tourName);

            if (tour == null)
            {
                throw new BookingPersonOnNonexistentTourException();
            }
            if (tour.NumberOfSeats < seats)
            {
                throw new BookingPersonOnTourWhereNoSeatsLeftException();
            }
            var booking = new Booking();
            booking.TourName = tourName;
            booking.DateOfTour = dateOfTour;
            booking.Seats = seats;
            booking.passenger = stubPassenger;
            bookings.Add(booking);
        }

        public List<Booking> GetBookingsFor(Passenger stubPassenger)
        {
            return bookings.Where(x => x.passenger.FirstName == stubPassenger.FirstName &&
                                       x.passenger.LastName == stubPassenger.LastName).ToList();
        }
    }
}