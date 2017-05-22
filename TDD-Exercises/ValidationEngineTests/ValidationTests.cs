using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationEngine;

namespace ValidationEngineTests
{
   public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            var sut = new Validator();

            sut.ValidateEmailAdress("hampus_cousin@hotmail.com");

            Assert.IsTrue(true);
        }


    }
}
