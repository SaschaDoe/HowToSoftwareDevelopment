using System;

namespace GuessingGame.GuessingGameFunctional
{
    public class ConsoleOutputProxy : IOutputProxy
    {
        public void SetOutput(string output)
        {
            Console.Write(output);
        }
    }
}