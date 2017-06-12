using System;
using System.Collections.Generic;

namespace TravelAgencyES4
{
    public interface ITourSchedule
    {
        List<Tour> listOfTours { get; set; }
        void CreateTour(string nameoftour, DateTime dateTime, int numberofseats);
        List<Tour> GetToursFor(DateTime timeTour);
    }
}