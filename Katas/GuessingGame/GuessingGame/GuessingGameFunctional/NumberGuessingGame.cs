using System;

namespace GuessingGame.GuessingGameFunctional
{
    public static class NumberGuessingGame
    {

        public static void ShowAskForMaxRangeMessage(IOutputProxy outputProxy)
        {
            outputProxy.SetOutput("Choose range: ");
        }
        
        public static void ShowStartGameMessage(IOutputProxy outputProxy)
        {
            outputProxy.SetOutput($"A new Guessing Game begins!{Environment.NewLine}");
        }

        public static UserInput GetRandomNumberRangeFromUser(IInputProxy inputProxy)
        {
            return new UserInput()
            {
                InputString = inputProxy.GetUserInput()
            };
        }
    }
}