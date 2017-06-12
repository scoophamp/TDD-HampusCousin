using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyES4;

namespace TravelAgencyExerciseFourTests
{
    [TestFixture]
    [Category("ExerciseFour TourScheduleTests")]
    public class TourScheduleTests
    {
        private TourSchedule sut;
        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }
        [Test]
        public void CanCreateNewTour()
        {
            //Act
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));

            //Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("New years day safari", result[0].NameOfTour);
            Assert.AreEqual(20, result[0].NumberOfSeats);

        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            //Act
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));

            //Assert
            Assert.AreEqual(new DateTime(2013, 1, 1), result[0].DateOfTour.Date);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("May safari", new DateTime(2013, 5, 1, 10, 15, 0), 20);
            sut.CreateTour("July safari", new DateTime(2013, 7, 1, 10, 15, 0), 20);
            sut.CreateTour("April safari", new DateTime(2013, 4, 1, 10, 15, 0), 20);

            var result = sut.GetToursFor(new DateTime(2013, 4, 1));

            Assert.AreEqual(new DateTime(2013, 4, 1), result[0].DateOfTour.Date);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void ThrowsExceptionWhenThereIsMoreThanOneTourPerDay()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("January safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("Winter safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("Winter safari", new DateTime(2013, 1, 1, 10, 15, 0), 20));
        }

        #region Stretch Task

        //To make the exception in the last point of the main task more helpful, 
        //it should suggest the next available date where there's a free slot, 
        //i.e. less than three scheduled tours.
        [Test]
        public void MoreThanOneTourSuggestNextTour()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("January safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("Winter safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            var e = Assert.Throws<TourAllocationException>(() => sut.CreateTour("A new in january safari", new DateTime(2013, 1, 1, 10, 15, 0), 20));
            Assert.AreEqual(new DateTime(2013, 1, 2), e.SuggestedTime, "Correct suggested time");
        }

        //The name of the tour is used to identify it within a given day. 
        //Trying to schedule a tour with the same name on the same date should throw an exception.

        [Test]
        public void ScheduleSameNameAndDateThrowException()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);


            Assert.Throws<SameNameSameDateException>(() =>
                sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20));
        }

        //•	Also make sure createTour throws an exception when the number of seats is negative.
        //Debate whether to make the exception in this case a TourAllocationException 
        //(or ask instructor). Also debate whether 0 should be an acceptable value.
        [Test]
        public void ShouldThrowExceptionWhenSeatsAreZeroOrNegative()
        {

            Assert.Throws<NegativeSeatException>(() =>
                sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), -1));

        }

        //Is it possible to ask for an unbooked day without getting an exception?
        [Test]
        public void IsItPossibleToAskForUnbookedDay()
        {
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual(0, result.Count);
        }

        #endregion
    }
}

