using System;
using GuessingGame.GuessingGameOOP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}