using System;
using System.IO;
using GuessingGame.GuessingGameOOP;
using GuessingGame.GuessingGameOOP.IO;
using GuessingGame.GuessingGameOOP.IO.Console;
using GuessingGameTests.UnitTests.GuessingGameOOP.IO;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GuessingGameTests.UnitTests.GuessingGameOOP
{
    [TestClass]
    public class GameControllerTests
    {
        #region Constructor

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_NewGameController()
        {
            const int maxRange = 1;
            var numberGuessingGame = new NumberGuessingGame(maxRange);
            var consoleProxy = new ConsoleOuputProxy();
            var consoleInputProxy = new ConsoleInputProxy();
            var gameController = new GameController(numberGuessingGame, consoleProxy, consoleInputProxy);
            
            Assert.AreEqual(numberGuessingGame, gameController.GuessingGame);
            Assert.AreEqual(consoleProxy, gameController.OutputProxy);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_NullArgumentException_WhenNumberGuessingGame_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new GameController(null, null,null));
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void Constructor_NullArgumentException_WhenProxy_Is_Null()
        {
            const int maxRange = 1;
            var numberGuessingGame = new NumberGuessingGame(maxRange);
            Assert.ThrowsException<ArgumentNullException>(() => new GameController(numberGuessingGame,null,null));
        }

        #endregion

        #region StartGame

        [TestMethod]
        [TestCategory("Unit")]
        public void StartGame()
        {
            const int maxRange = 1;
            var numberGuessingGame = new NumberGuessingGame(maxRange);
            var consoleProxy = new ConsoleOuputProxy();
            var consoleInputProxy = new ConsoleInputProxy();
            var gameController = new GameController(numberGuessingGame, consoleProxy, consoleInputProxy);

            using var consoleOutput = new ConsoleOutput();
            gameController.StartGame();
            
            Assert.AreEqual($"Welcome to guessing game!{Environment.NewLine}Enter max range: ",
                consoleOutput.GetOutput());
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void StartGame_InputMaxRange()
        {
            const int maxRange = 1;
            var numberGuessingGame = new NumberGuessingGame(maxRange);
            var consoleOutputProxy = new ConsoleOuputProxy();
            var consoleInputProxyRep = new Mock<IInputProxy>();
            consoleInputProxyRep.Setup(x => x.GetMaxRange()).Returns("1");
            
            var gameController = new GameController(numberGuessingGame, consoleOutputProxy, consoleInputProxyRep.Object);

            using var consoleOutput = new ConsoleOutput();
            gameController.StartGame();
            
            Assert.AreEqual(1,gameController.GuessingGame.MaxRange);
        }

        #endregion
    }
}