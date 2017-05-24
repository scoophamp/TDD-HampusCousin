using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag2
{
    public class Class1
    {
        //Some nice assertion examples
        
        public class Enemy : IEquatable<Enemy> //IEqual tvingar en att ha en metod för att jämföra objekt
        {
            public string Weapon { get; set; }

            public bool Equals(Enemy other)
            {
                if (other == null)
                {
                    return false;
                }
                return Weapon == other.Weapon;
            }
            //public static bool operator ==(Enemy a, Enemy b)
            //{
            //    if (ReferenceEquals(a,b))
            //    {
            //        return true;
            //    }
            //    return a.Weapon == b.Weapon;
            //}
            //public static bool operator !=(Enemy a, Enemy b)
            //{
            //    return !(a == b);
            //}
        }
        private DateTime sut;
        [SetUp]                            //Sätter sut:en i varje test
        public void Setup()
        {
            sut = DateTime.Now;
        }
        [TearDown]                         //Körs efter varje test
        public void TearDown()
        {

        }

        [Test]
        public void TryingAreEqual()
        {
            var enemy1 = new Enemy { Weapon = "Axe" };
            var enemy2 = new Enemy { Weapon = "Axe" };

            Assert.AreEqual(enemy1, enemy2); //En metod krävs för att jämföra 
            Assert.AreEqual(2, 1 + 1);

           // Assert.True(enemy1 == enemy2);

        }
        [Test]
        public void TryingTrue()
        {
            Assert.True(2 < 3);
        }
        [Test]
        public void TryingFalse()
        {
            Assert.False(2 > 3);
        }
        [Test]
        public void TryingContaints()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            Assert.Contains(2, numbers);
            //Assert.Contains(10, numbers);

        }
        [Test]
        public void TryingCollectionAsserr()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5 };
            var numbers2 = new int[] { 1, 2, 3 };

            CollectionAssert.IsSubsetOf(numbers2, numbers); 
        }
        [Test]
        public void TryingStringAsser()
        {
            StringAssert.DoesNotMatch(@"\d", "asda"); //regexer.com

        }
        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(3, 5, 8)]

        public void CanAdd(int a, int b, int ex)
        {
            Assert.AreEqual(ex, a + b);
        }
        //Inte nödvändigt att kunna
        [Test, Sequential]
        public void CanAddAgain([Values(1,2,3)]int a, [Values(2, 2, 3)]int b, [Values(3, 4, 6)]int exp)
        {
            Assert.AreEqual(exp, a + b);
        }

    }
}
