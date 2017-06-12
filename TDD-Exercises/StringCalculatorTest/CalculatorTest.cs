using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestFixture]
    [Category("ExerciseThree")]
    public class CalculatorTests
    {
        private Calculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new Calculator();
        }

        [Test]
        public void AddEmptyStringReturnZero()
        {
            var result = sut.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void AddOneNumberReturnTheSumOfTheNumber()
        {
            var result = sut.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void AddTwoDifferentNumbersReturnTheSumOfTheNumbers()
        {
            var result = sut.Add("1,11");

            Assert.AreEqual(12, result);
        }

        [Test]
        public void AddNumberThatIsSplitOnNewLine()
        {
            var result = sut.Add("1\n2,3");
            //var result = sut.Add("1,\n");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void AddNegativeNumberShouldThrowExceptions()
        {
            Assert.Throws<NegativeNumberException>(() => sut.Add("-10"));
        }

        [Test]
        public void AddNumberBiggerThanThousandShouldBeIgnored()
        {
            var result = sut.Add("1,1001");
            Assert.AreEqual(1, result);
        }
    }
}
