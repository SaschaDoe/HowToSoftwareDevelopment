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
        public void Evaluate_Right_When_Equal()
        {
            const int maxRange = 1;
            var numberGuessingGameMock = new NumberGuessingGame(maxRange);
            
            var mockRep = new Mock<NumberGuessingGame>(numberGuessingGameMock)
                .As<INumberGuessingGame>();
            mockRep.Setup(x => x.RandomNumber).Returns(0);
            
            Assert.AreEqual(GuessResult.Right,numberGuessingGameMock.Evaluate(0));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Evaluate_ToBig_When_Guess_Is_Greater()
        {
            const int maxRange = 1;
            var numberGuessingGameMock = new NumberGuessingGame(maxRange);
            
            var mockRep = new Mock<NumberGuessingGame>(numberGuessingGameMock)
                .As<INumberGuessingGame>();
            mockRep.Setup(x => x.RandomNumber).Returns(0);

            Assert.AreEqual(GuessResult.ToBig,numberGuessingGameMock.Evaluate(1));
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Evaluate_ToSmall_When_Guess_Is_Smaller()
        {
            const int maxRange = 1;
            var randomMock = new Mock<IRandom>();
            randomMock.Setup(x => x.Next(0,maxRange)).Returns(1);
            var numberGuessingGame = new NumberGuessingGame(maxRange,randomMock.Object);
            numberGuessingGame.GenerateNewRandomNumber();

            var evaluation = numberGuessingGame.Evaluate(0);
            
            Assert.AreEqual(GuessResult.ToSmall,evaluation);
        }

        #endregion
    }
}