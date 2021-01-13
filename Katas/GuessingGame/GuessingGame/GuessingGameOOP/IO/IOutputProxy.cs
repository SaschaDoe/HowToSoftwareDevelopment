namespace GuessingGame.GuessingGameOOP.IO
{
    public interface IOutputProxy
    {
        void Show(GuessResult guessResult);
        void ShowStartMessage();
        void ShowNewRound();
        void ShowWinningMessage();
        void ShowGreater();
        void ShowSmaller();
        void ShowEnterMaxRangeMessage();

    }
}