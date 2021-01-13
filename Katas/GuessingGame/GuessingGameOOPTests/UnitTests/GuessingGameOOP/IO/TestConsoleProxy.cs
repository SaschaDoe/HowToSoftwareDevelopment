using System;
using GuessingGame.GuessingGameOOP;
using GuessingGame.GuessingGameOOP.IO;
using GuessingGame.GuessingGameOOP.IO.Console;

namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class TestConsoleProxy : IInputProxy
    {
        public string GetMaxRange()
        {
            return "1";
        }
    }
}