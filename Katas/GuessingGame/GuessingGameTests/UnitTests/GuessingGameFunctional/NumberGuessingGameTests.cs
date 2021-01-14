using System;
using GuessingGame.GuessingGameFunctional;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using static GuessingGame.GuessingGameFunctional.NumberGuessingGame;

namespace GuessingGameTests.UnitTests.GuessingGameFunctional
{
    [TestClass]
    public class NumberGuessingGameTests
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
        public void ConsoleOutput_ShowStartGameMessage()
        {
            using var consoleOutputListener = new ConsoleOutputListener();
            var consoleOutputProxy = new ConsoleOutputProxy();
            ShowStartGameMessage(consoleOutputProxy);
            
            Assert.AreEqual($"A new Guessing Game begins!{Environment.NewLine}",consoleOutputListener.GetOutput());
        }
        
        
        [TestMethod]
        [TestCategory("Unit")]
        public void ConsoleOutput_ShowAskForMaxRangeMessage()
        {
            using var consoleOutputListener = new ConsoleOutputListener();
            var consoleOutputProxy = new ConsoleOutputProxy();
            ShowAskForMaxRangeMessage(consoleOutputProxy);
            
            Assert.AreEqual($"Choose range: ",consoleOutputListener.GetOutput());
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void GetRandomNumberRange_FromUser_1_When_Input1()
        {
            var consoleInputRep = new Mock<IInputProxy>();
            consoleInputRep.Setup(x => x.GetUserInput()).Returns("1");

            var randomUserInput= GetRandomNumberRangeFromUser(consoleInputRep.Object);

            Assert.AreEqual(1,randomUserInput.MaxRange);
            Assert.IsFalse(randomUserInput.IsQuit);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void GetRandomNumberRange_FromUser_2_When_Input2()
        {
            var consoleInputRep = new Mock<IInputProxy>();
            consoleInputRep.Setup(x => x.GetUserInput()).Returns("2");

            var randomUserInput= GetRandomNumberRangeFromUser(consoleInputRep.Object);

            Assert.AreEqual(2,randomUserInput.MaxRange);
            Assert.IsFalse(randomUserInput.IsQuit);
        }

        [TestMethod]
        [TestCategory("Unit")]
        public void GetRandomNumberRange_FromUser_UserInputQuit_When_Quit()
        {
            var consoleInputRep = new Mock<IInputProxy>();
            consoleInputRep.Setup(x => x.GetUserInput()).Returns("quit");

            var randomUserInput= GetRandomNumberRangeFromUser(consoleInputRep.Object);
            
            Assert.IsTrue(randomUserInput.IsQuit);
        }

    }
}

