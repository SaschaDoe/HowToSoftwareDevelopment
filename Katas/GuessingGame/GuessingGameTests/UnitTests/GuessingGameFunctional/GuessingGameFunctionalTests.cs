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
            
            Assert.AreEqual(1,userInput.InputInt);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void GetMaxRange_ConsoleInput_IsQuit_When_UserQuits()
        {
            var consoleInputRep = new Mock<IInputProxy>();
            consoleInputRep.Setup(x => x.GetInput()).Returns("quit");
            
            var maxRange = NumberGuessingGame.GetMaxRange(consoleInputRep.Object);
            
            Assert.AreEqual(1,maxRange);
        }


    }
}