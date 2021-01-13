namespace GuessingGame.GuessingGameOOP
{
    public interface INumberGuessingGame
    {
        int MaxRange { get; }
        GuessResult Evaluate(int guess);
        int RandomNumber { get; }
        
        void GenerateNewRandomNumber();
    }
}