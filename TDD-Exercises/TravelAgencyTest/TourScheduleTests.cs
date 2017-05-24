using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTest
{
   public class TourScheduleTests
    {
        private TourSchedule sut; //Private fält för att alla ska komma åt den

        [SetUp] //För varje test så sätts en sut
        public void Setup()
        {
           sut = new TourSchedule(); //Sut för varje [Test], OBS var försikt att inte deklarera en ny
        }

        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour(
            "New years day safari",
            new DateTime(2013, 1, 1), 20);


            var res = sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(1, res.Count);
            Assert.AreEqual("New years day safari", res[0].Name);
            Assert.AreEqual(20, res[0].Seats);


        }
        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);

            var res = sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(new DateTime(2013, 1, 1), res[0].TourDate.Date);
        }
        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(
           "Hej och hå",
           new DateTime(2014, 7, 1), 20);

            sut.CreateTour(
           "Börje",
           new DateTime(2013, 6, 1), 20);

            sut.CreateTour(
           "New years day safari",
           new DateTime(2013, 5, 1), 20);

            var res = sut.GetToursFor(new DateTime(2013, 6, 1));

            Assert.AreEqual(new DateTime(2013, 6, 1), res[0].TourDate.Date);

        }
        [Test]
        public void TestingException()
        {
            sut.CreateTour(
          "Hej och hå",
          new DateTime(2014, 7, 1), 20);
            sut.CreateTour(
          "Hej och rå",
          new DateTime(2014, 7, 1), 20);
            sut.CreateTour(
          "Hej och gå",
          new DateTime(2014, 7, 1), 20);

        

            Assert.Throws<SameDateException>(()=>
              sut.CreateTour(
          "Hej och gå",
          new DateTime(2014, 7, 1), 20)
            );


            
        }



    }
}
