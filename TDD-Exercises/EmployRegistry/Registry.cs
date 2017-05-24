using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployRegistry
{
    public class Registry : IRegistry
    {
        private Dictionary<string, Employee> employees;
        private Regex PnrRegex = new Regex(@"^\d{6}-\d{4}$");


        public Registry()
        {
            employees = new Dictionary<string, Employee>();
        }

        public Registry(Dictionary<string, Employee> Newemployees)  //ctor tab tab är construktor
        {
            employees = Newemployees;
        }

        public List<Employee> AllEmployees()
        {
            return employees.Values.ToList();
        }

        public void Fire(string pnr)
        {
           
        }

        public void Hire(Employee employee)
        {
            if (!PnrRegex.IsMatch(employee.PNummer))
            {
                throw new InvalidPnr();
            }
            employees.Add(employee.PNummer, employee);
        }
    }
}
