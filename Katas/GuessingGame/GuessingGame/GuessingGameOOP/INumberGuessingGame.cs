namespace GuessingGame.GuessingGameOOP
{
    public interface INumberGuessingGame
    {
        int MaxRange { get; }
        bool Evaluate(int guess);
        int RandomNumber { get; }
        
        void GenerateNewRandomNumber();
    }
}