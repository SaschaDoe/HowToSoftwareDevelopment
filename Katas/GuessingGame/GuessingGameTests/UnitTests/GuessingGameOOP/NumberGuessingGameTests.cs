using System;
using GuessingGame.GuessingGameOOP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GuessingGameTests.UnitTests.GuessingGameOOP
{
    [TestClass]
    public class NumberGuessingGameTests
    {

        #region Constructor

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_Exception_When_RangeIsSmaller1()
        {
            const int maxRange = 0;
            var exception = Assert.ThrowsException<ArgumentException>(() => new NumberGuessingGame(maxRange));
            Assert.AreEqual($"Range {maxRange} is under 1", exception.Message);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_SetMaxRange()
        {
            const int maxRange = 1;
            var actualNumberGuessingGame =  new NumberGuessingGame(maxRange);
            
            Assert.AreEqual(1, actualNumberGuessingGame.MaxRange);
        }

        #endregion

        #region Evaluate

        [TestMethod]
        [TestCategory("Unit")]
        public void Evaluate_True_When_Equal()
        {
            const int maxRange = 1;
            var numberGuessingGameMock = new NumberGuessingGame(maxRange);
            
            var mockRep = new Mock<NumberGuessingGame>(numberGuessingGameMock)
                .As<INumberGuessingGame>();
            mockRep.Setup(x => x.RandomNumber).Returns(0);

            Assert.IsTrue(numberGuessingGameMock.Evaluate(0));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Evaluate_False_When_NotEqual()
        {
            const int maxRange = 1;
            var numberGuessingGameMock = new NumberGuessingGame(maxRange);
            
            var mockRep = new Mock<NumberGuessingGame>(numberGuessingGameMock)
                .As<INumberGuessingGame>();
            mockRep.Setup(x => x.RandomNumber).Returns(0);

            Assert.IsFalse(numberGuessingGameMock.Evaluate(1));
        }

        #endregion
    }
}