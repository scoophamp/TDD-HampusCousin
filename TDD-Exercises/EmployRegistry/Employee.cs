using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployRegistry
{
   public class Employee
    {
        public string FName { get;private set; }
        public string LName { get;private set; }
        public string PNummer { get;private set; }

        public Employee(string fname, string lname, string pnr)
        {
            FName = fname;
            LName = lname;
            PNummer = pnr;
        }
    }
}
