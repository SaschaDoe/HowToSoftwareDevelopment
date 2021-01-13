using System;

namespace GuessingGame.GuessingGameOOP
{
    public class NumberGuessingGame : INumberGuessingGame
    {
        private readonly IRandom _random;
        private const int MinimalRange = 1;

        public NumberGuessingGame(int maxRange, IRandom random = null)
        {
            if (random == null)
            {
                _random = new Randomizer();
            }
            
            if (maxRange < MinimalRange)
            {
                throw new ArgumentException($"Range {maxRange} is under {MinimalRange}");
            }

            _random = random;

            MaxRange = maxRange;
        }

        public int MaxRange { get; }
        public GuessResult Evaluate(int guess)
        {
            if (guess == RandomNumber)
            {
                return GuessResult.Right;
            }
            if (guess < RandomNumber)
            {
                return GuessResult.ToSmall;
            }
            else
            {
                return GuessResult.ToBig;
            }
        }

        public int RandomNumber { get; private set; }

        public void GenerateNewRandomNumber()
        {
            RandomNumber = _random.Next(0,MaxRange);
        }
    }
}