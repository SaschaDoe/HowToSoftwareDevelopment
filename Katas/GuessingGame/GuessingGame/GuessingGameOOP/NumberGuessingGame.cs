using System;

namespace GuessingGame.GuessingGameOOP
{
    public class NumberGuessingGame : INumberGuessingGame
    {
        private const int MinimalRange = 1;

        public NumberGuessingGame(int maxRange)
        {
            if (maxRange < MinimalRange)
            {
                throw new ArgumentException($"Range {maxRange} is under {MinimalRange}");
            }

            MaxRange = maxRange;
        }

        public int MaxRange { get; }
        public bool Evaluate(int guess)
        {
            return guess == RandomNumber;
        }

        public int RandomNumber { get; }
        public void GenerateNewRandomNumber()
        {
            throw new NotImplementedException();
        }
    }
}