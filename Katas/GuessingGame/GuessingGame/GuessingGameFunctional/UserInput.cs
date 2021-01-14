using System;

namespace GuessingGame.GuessingGameFunctional
{
    public class UserInput
    {
        public int MaxRange
        {
            get
            {
                return Convert.ToInt32(InputString);
            }
        }

        public bool IsQuit
        {
            get
            {
                if (InputString.Equals("quit"))
                {
                    return true;
                }

                return false;
            }
        }

        public string InputString { get; set; }
    }
}