using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyES4;

namespace TravelAgencyES4Test
{
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> listOfTours { get; set; }
        public List<DateTime> CallsToGetToursFor;

        public TourScheduleStub()
        {

        }
        public void CreateTour(string nameoftour, DateTime tourDateTime, int numberofseats)
        {

        }

        public List<Tour> GetToursFor(DateTime timeTour)
        {
            if (CallsToGetToursFor == null)
            {
                CallsToGetToursFor = new List<DateTime>();
            }
            CallsToGetToursFor.Add(timeTour);
            return listOfTours;
        }
    }
}
