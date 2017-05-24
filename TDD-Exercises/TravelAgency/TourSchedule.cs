using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> ListOfTours = new List<Tour>();
        public void CreateTour(string name, DateTime date, int seats)
        {
            var res = ListOfTours.Count(x => x.TourDate.Date == date.Date);

            if (res >= 3)
            {
                throw new SameDateException();
            }
             
            ListOfTours.Add(new Tour
        {
            Name = name,
            TourDate = date,
            Seats = seats
        });
        }

    public List<Tour> GetToursFor(DateTime dateTime)
    {
           
            return ListOfTours.Where(x => x.TourDate.Date == dateTime.Date).ToList();
    }
      

    }
}
