using EmployRegistry;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployRegistryTest
{
   public class RegistryTest
    {
        private Registry sut;
        private Dictionary<string, Employee> employees;
        private Employee employee1;
        private Employee employee2;


        [SetUp]
        public void Setup()
        {
            employees = new Dictionary<string, Employee>();
            employee1 = new Employee("Martin", "Nilsson", "8080-8080");
            employee2 = new Employee("Hampus", "Cousin", "9090-9090");

            sut = new Registry();
        }

        [Test]
        public void StartWithZeroEmployees()
        {
            var res = sut.AllEmployees();

            Assert.IsNotNull(res); //Kollar om listan inte är null
            Assert.AreEqual(0, res.Count); //Kollar om listan är count 0
        }
        [Test]
        public void CanSeedEmployeesOnContruct()
        {
            employees.Add(employee1.PNummer, employee1);
            employees.Add(employee2.PNummer, employee2);

            sut = new Registry(employees);

            var res = sut.AllEmployees();

            Assert.AreEqual(2, res.Count);
        }
        [Test]
        public void CanHireAnEmployee()
        {
            var employeee = new Employee("Agda","Knutsson","202020-2020");

            sut.Hire(employeee);
            var res = sut.AllEmployees();

            Assert.AreEqual(1, res.Count);
            Assert.AreEqual("Agda", res[0].FName);
        }
        [Test]
        public void HireWithInvalidPNr_ThrowsException()
        {
            var employeee = new Employee("Urban", "Svensson", "2020aa-2020");
            
            Assert.Throws<InvalidPnr>(()=> 
            {
                sut.Hire(employeee);
            });
        }
    }
}
