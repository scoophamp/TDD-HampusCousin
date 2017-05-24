using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployRegistry
{
    interface IRegistry
    {
        List<Employee> AllEmployees();
        void Fire(string pnr);
        void Hire(Employee employee);
    }
}
