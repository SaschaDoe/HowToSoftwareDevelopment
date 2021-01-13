using System;

namespace GuessingGame.GuessingGameOOP
{
    public class Randomizer : IRandom
    {
        private Random _random;
        
        public Randomizer()
        {
            _random = new Random();
        }
        
        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}