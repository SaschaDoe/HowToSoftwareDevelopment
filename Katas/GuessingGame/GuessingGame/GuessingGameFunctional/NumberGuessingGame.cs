using System;

namespace GuessingGame.GuessingGameFunctional
{
    public class NumberGuessingGame
    {
        public static void ShowStartGameMessage()
        {
            Console.Write($"New Guessing Game begins!{Environment.NewLine}");
        }

        public static void ShowAskForMaxRange()
        {
            Console.Write("Input max range: ");
        }

        public static UserInput GetMaxRange(IInputProxy consoleInputProxy)
        {
            return new UserInput()
            {
                InputString = consoleInputProxy.GetInput()
            };
        }
    }
}