using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ExtraExercise3NSubstitute;

namespace ExtraExercise3NSubstitudeTest
{
    [TestFixture]
    [Category("ExerciseNSubstitute")]
    public class ExtraExercise3NSubstitute
    {
        private IAuditLogger iAuditLoggerMock;
        private Bank sut;
        private Account account;

        [SetUp]
        public void Setup()
        {
            iAuditLoggerMock = Substitute.For<IAuditLogger>();
            sut = new Bank(iAuditLoggerMock);
            account = new Account();
            account.Name = "Lisa";
            account.Number = "1";
            account.Balance = 0;
        }

        [Test]
        public void CanCreateBankAccount()
        {
            //Arrange
            sut.CreateAccount(account);

            //Act
            var result = sut.GetAccount("1");

            //Assert
            Assert.AreEqual("1", result.Number);
            Assert.AreEqual("Lisa", result.Name);
            Assert.AreEqual(0, result.Balance);
        }
        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            //Arrange
            sut.CreateAccount(account);

            //Act
            //Assert
            Assert.Throws<DuplicateAccount>(() =>
                sut.CreateAccount(account));
        }
        [Test]
        public void WhenCreatingAnAccount_AMessageIsWrittenToTheAuditLog()
        {
            //Arrange
            sut.CreateAccount(account);
            //Act

            //Assert
            iAuditLoggerMock.Received().AddMessage(Arg.Is<string>(a => a.Contains(account.Name) && a.Contains(account.Number)));
        }
        [Test]
        public void WhenCreatingAnValidAccount_OneMessageAreWrittenToTheAuditLog()
        {
            //Arrange

            //Act
            sut.CreateAccount(account);
            //Assert
            iAuditLoggerMock.Received(1).AddMessage(Arg.Any<string>());
        }
        [Test]
        public void WhenCreatingAnInvalidAccount_TwoMessagesAreWrittenToTheAuditLog()
        {
            //Arrange
            Account invalidAccount = new Account() { Name = "Anna", Number = "hej", Balance = 100 };
            //Act

            //Assert
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(invalidAccount));
            iAuditLoggerMock.Received(2).AddMessage(Arg.Any<string>());

        }
        [Test]
        public void WhenCreatingAnInvalidAccount_AWarn12AndErro45MessageIsWrittenToAuditLog()
        {
            //Arrange
            Account invalidAccount = new Account() { Name = "Anna", Number = "hej", Balance = 100 };

            //Act
            //Assert
            Assert.Throws<InvalidAccount>(() => sut.CreateAccount(invalidAccount));
            iAuditLoggerMock.Received().AddMessage(Arg.Is<string>(m => m.Contains("Warn12") || m.Contains("Error45")));
        }
        [Test]
        public void VerifyThat_GetAuditLog_GetsTheLogFromTheAuditLogger()
        {
            //Arrange
            iAuditLoggerMock.GetLog().Returns(new List<string>() { "OneItem", "TwoItem", "ThreeItem" });
            //Act
            var result = sut.GetAuditLog();
            //Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
