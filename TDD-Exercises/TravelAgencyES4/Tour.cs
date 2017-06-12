using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyES4
{
    public class Tour
    {
        public string NameOfTour { get; set; }
        public DateTime DateOfTour { get; set; }
        public int NumberOfSeats { get; set; }

        public Tour()
        {

        }

        public Tour(string tourname, DateTime tourdate, int numberofseats)
        {
            this.NameOfTour = tourname;
            this.DateOfTour = tourdate;
            this.NumberOfSeats = numberofseats;
        }
    }
}
