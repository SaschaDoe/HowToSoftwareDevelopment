using System;
using GuessingGame.GuessingGameOOP.IO;
using GuessingGame.GuessingGameOOP.IO.Console;
using GuessingGameTests.UnitTests.GuessingGameOOP.IO;

namespace GuessingGame.GuessingGameOOP
{
    public class GameController
    {
        public GameController(NumberGuessingGame guessingGame, IOutputProxy outputProxy, IInputProxy inputProxy)
        {
            GuessingGame = guessingGame ?? throw new ArgumentNullException(nameof(guessingGame));
            OutputProxy = outputProxy ?? throw new ArgumentNullException(nameof(outputProxy));
            InputProxy = inputProxy ?? throw new ArgumentNullException(nameof(inputProxy));
        }

        public NumberGuessingGame GuessingGame { get; private set; }
        public IOutputProxy OutputProxy { get; }
        public IInputProxy InputProxy { get; }

        public void StartGame()
        {
            OutputProxy.ShowStartMessage();
            OutputProxy.ShowEnterMaxRangeMessage();
            var maxRange = InputProxy.GetMaxRange();
            var randomNumberRange = new RandomNumberRange()
            {
                Max = Convert.ToInt32(maxRange)
            };
            GuessingGame = new NumberGuessingGame(randomNumberRange);
        }
    }
}