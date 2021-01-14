using System;

namespace GuessingGame.GuessingGameFunctional
{
    public class UserInput
    {
        public string InputString { get; init; }

        public int InputInt
        {
            get
            {
                return Convert.ToInt32(InputString);
            }
        }

        public bool IsQuit { get; }
    }
}