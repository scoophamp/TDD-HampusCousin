using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TravelAgencyES4;
using TravelAgencyES4Test;

namespace TravelAgencyES4Tests
{
    [TestFixture]
    [Category("ExerciseFour BookinSystemTests")]
    public class BookingSystemTests
    {
        private BookingSystem sut;
        private TourScheduleStub tourScheduleStub { get; set; }
        private Passenger StubPassenger;


        [SetUp]
        public void Setup()
        {
            tourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(tourScheduleStub);
            StubPassenger = new Passenger()
            {
                FirstName = "Kalle",
                LastName = "Anka"
            };
        }

        [Test]
        public void CanCreateBooking()
        {
            //Arrange
            tourScheduleStub.listOfTours = new List<Tour>();
            tourScheduleStub.listOfTours.Add(new Tour
            {
                NameOfTour = "Wild Tour",
                DateOfTour = new DateTime(2018, 1, 1),
                NumberOfSeats = 10
            });

            //Act
            sut.CreateBooking("Wild Tour", new DateTime(2018, 1, 1), 10, StubPassenger);

            List<Booking> bookingsList = sut.GetBookingsFor(StubPassenger);

            //Assert
            var model = bookingsList[0];

            Assert.AreEqual(1, bookingsList.Count);
            Assert.AreEqual("Wild Tour", model.TourName);
            Assert.AreEqual(StubPassenger, model.passenger);
            Assert.AreEqual(tourScheduleStub.listOfTours[0].NameOfTour, model.TourName);

        }

        [Test]
        public void BookingAPassengerOnANonExistentTourThrowsException()
        {
            //Arrange
            tourScheduleStub.listOfTours = new List<Tour>();

            //Act

            //Assert
            Assert.Throws<BookingPersonOnNonexistentTourException>(() =>
            sut.CreateBooking("Wild Tour", new DateTime(2018, 1, 1), 10, StubPassenger));
        }

        [Test]
        public void BookingAPassengerOnTourWithNoSeatsLeftThrowsException()
        {
            //Arrange
            tourScheduleStub.listOfTours = new List<Tour>();
            tourScheduleStub.listOfTours.Add(new Tour
            {
                NameOfTour = "Wild Tour",
                DateOfTour = new DateTime(2018, 1, 1),
                NumberOfSeats = 10
            });

            //Act
            //Assert
            Assert.Throws<BookingPersonOnTourWhereNoSeatsLeftException>(() =>
                sut.CreateBooking("Wild Tour", new DateTime(2018, 1, 1), 12, StubPassenger));
        }
    }
}

