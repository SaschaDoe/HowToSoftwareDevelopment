using System;

namespace GuessingGame.GuessingGameFunctional
{
    public class UserInput
    {
        public string InputString { get; init; }

        public bool ParseToInt(out int value)
        {
            return int.TryParse(InputString,out value);
        }

        public bool IsQuit
        {
            get
            {
                if (InputString.Equals("quit") || InputString.Equals("Quit"))
                {
                    return true;
                }

                return false;
            }
        }
    }
}