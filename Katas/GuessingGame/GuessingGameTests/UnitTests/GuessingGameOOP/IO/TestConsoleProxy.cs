using System;
using GuessingGame.GuessingGameOOP;
using GuessingGame.GuessingGameOOP.IO;

namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class TestConsoleProxy : IOutputProxy
    {
        public void Show(GuessResult guessResult)
        {
            throw new System.NotImplementedException();
        }

        public void ShowStartMessage()
        {
            Console.WriteLine($"Welcome to guessing game!{Environment.NewLine}");
        }

        public void ShowNewRound()
        {
            throw new System.NotImplementedException();
        }

        public void ShowWinningMessage()
        {
            throw new System.NotImplementedException();
        }

        public void ShowGreater()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSmaller()
        {
            throw new System.NotImplementedException();
        }

        public void ShowEnterMaxRangeMessage()
        {
            throw new System.NotImplementedException();
        }

        public string GetMaxRange()
        {
            return "1";
        }
    }
}