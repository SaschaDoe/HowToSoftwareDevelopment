namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class RandomNumberRange
    {
        private int _max;
        public int Min => 0;

        public int Max
        {
            get
            {
                return _max;
            }
            set
            {
                _max = value;
            }
        }
    }
}