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
        public void IfEmtyReturnFalse()
        {
            var sut = new Validator();
            var res = sut.ValidateEmailAdress("");                  
            Assert.IsFalse(res);
            
        }


    [Test]
        public void TrueForValidAddress()
        {
            var sut = new Validator(); //Arrange

          var res =  sut.ValidateEmailAdress("hampus_cousin@hotmail.com"); //Act
            
            Assert.IsTrue(res); //Assert
        }
       [Test]
       public void CheckIfInvalid()
        {
            var sut = new Validator(); //Arrange

           var res = sut.ValidateEmailAdress("lusfb43iu5y523hufn"); //Act

            Assert.IsFalse(res); //Assert
        }
       
    }
}
