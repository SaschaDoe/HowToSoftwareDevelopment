using System;

namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class RandomNumberRange
    {
        private int _max;
        public int Min
        {
            get { return 0; }
        }

        public int Max
        {
            get
            {
                return _max;
            }
            init
            {
                if (value <= Min)
                {
                    throw new ArgumentException($"Range {value} is under or equal {Min}");
                }
                _max = value;
            }
        }
    }
}