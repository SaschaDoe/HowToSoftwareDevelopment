using System;
using GuessingGameTests.UnitTests.GuessingGameOOP.IO;

namespace GuessingGame.GuessingGameOOP
{
    public class NumberGuessingGame : INumberGuessingGame
    {
        private readonly IRandom _random;

        public NumberGuessingGame(RandomNumberRange maxRange, IRandom random = null)
        {
            if (random == null)
            {
                _random = new Randomizer();
            }
            
           

            _random = random;

            MaxRange = maxRange.Max;
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