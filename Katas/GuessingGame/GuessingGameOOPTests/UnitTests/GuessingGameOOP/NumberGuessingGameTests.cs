using System;
using GuessingGame.GuessingGameOOP;
using GuessingGameTests.UnitTests.GuessingGameOOP.IO;
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
        public void Constructor_SetMaxRange()
        {
            var maxRange = new RandomNumberRange()
            {
                Max = 1
            };
            var actualNumberGuessingGame =  new NumberGuessingGame(maxRange);
            
            Assert.AreEqual(1, actualNumberGuessingGame.MaxRange);
        }

        #endregion

        #region Evaluate

        [TestMethod]
        [TestCategory("Unit")]
        public void Evaluate_Right_When_Equal()
        {
            var maxRange = new RandomNumberRange()
            {
                Max = 1
            };
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
            var maxRange = new RandomNumberRange()
            {
                Max = 1
            };
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
            var range = new RandomNumberRange()
            {
                Max = 1
            };
            var randomMock = new Mock<IRandom>();
            randomMock.Setup(x => x.Next(0,range.Max)).Returns(1);
            var numberGuessingGame = new NumberGuessingGame(range,randomMock.Object);
            numberGuessingGame.GenerateNewRandomNumber();

            var evaluation = numberGuessingGame.Evaluate(0);
            
            Assert.AreEqual(GuessResult.ToSmall,evaluation);
        }

        #endregion
    }
}