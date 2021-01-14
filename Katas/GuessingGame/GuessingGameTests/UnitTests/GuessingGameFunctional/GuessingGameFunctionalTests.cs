using System;
using GuessingGame.GuessingGameFunctional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GuessingGameTests.UnitTests.GuessingGameFunctional
{
    [TestClass]
    public class GuessingGameFunctionalTests
    {
        //TODO: -Show oder FromUSer Indicates unpure function rule of three beachten!
        //ShowStartGameMessage
        //ShowAskForMaxRangeMessage
        //GetMaxRangeFromUser -> GetInput -> ExitIfQuitMessage -> IsNumberEvaluation -> IsInsideRangeEvaluation 
        //New Round:
        //GenerateNewRandomNumber
        //New Turn:
        //ShowGuessMessage
        //GetGuessFromUser -> GetInput -> ExitIfQuitMessage -> IsNumberEvaluation -> IsInsideRangeEvaluation
        //EvaluateGuess
        //ShowRightMessage -> NewRound
        //ShowGreaterMessage -> NewTurn
        //ShowSmallerMessage -> NewTurn

        [TestMethod]
        [TestCategory("Unit")]
        public void ShowStartGameMessage_ConsoleOutput()
        {
            using var consoleOutputListener = new ConsoleOutputListener();
            NumberGuessingGame.ShowStartGameMessage();
            
            Assert.AreEqual($"New Guessing Game begins!{Environment.NewLine}",consoleOutputListener.GetOutput());
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ShowAsForMaxRange_ConsoleOutput()
        {
            using var consoleOutputListener = new ConsoleOutputListener();
            NumberGuessingGame.ShowAskForMaxRange();
            
            Assert.AreEqual($"Input max range: ",consoleOutputListener.GetOutput());
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void GetMaxRange_ConsoleInput()
        {
            var consoleInputRep = new Mock<IInputProxy>();
            consoleInputRep.Setup(x => x.GetInput()).Returns("1");
            var userInput = NumberGuessingGame.GetMaxRange(consoleInputRep.Object);

            var isNumber = userInput.ParseToInt(out var intValue);
            
            Assert.IsTrue(isNumber);
            Assert.AreEqual(1,intValue);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void GetMaxRange_ConsoleInput_IsQuit_When_UserQuits()
        {
            var userInput = new UserInput()
            {
                InputString = "Quit"
            };
            
            Assert.IsTrue(userInput.IsQuit);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void GetMaxRange_ConsoleInput_IsQuit_When_UserQuits_WithUpperCase()
        {
            var userInput = new UserInput()
            {
                InputString = "Quit"
            };
            
            Assert.IsTrue(userInput.IsQuit);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void UserInput_IsNotANumber()
        {
            var userInput = new UserInput()
            {
                InputString = "quit"
            };

            var isNumber = userInput.ParseToInt(out var intValue);
            
            Assert.IsFalse(isNumber);
            Assert.AreEqual(0,intValue);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ShowExitMessage_When_Quit()
        {
            var userInput = new UserInput()
            {
                InputString = "quit"
            };
            using var consoleOutputListener = new ConsoleOutputListener();
            NumberGuessingGame.ShowExitMessage(userInput);

            Assert.AreEqual($"Game quit.{Environment.NewLine}",consoleOutputListener.GetOutput());
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ShowMaxRangeMustBeGreaterZeroMessage()
        {
            var userInput = new UserInput()
            {
                InputString = "0"
            };
            using var consoleOutputListener = new ConsoleOutputListener();
            NumberGuessingGame.ShowMaxRangeMustBeGreaterZeroMessage(userInput);

            Assert.AreEqual($"Max Range must be greater zero.{Environment.NewLine}",consoleOutputListener.GetOutput());
        }

    }
}