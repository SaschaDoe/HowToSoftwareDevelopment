namespace GuessingGame.GuessingGameOOP.IO.Console
{
    public class ConsoleInputProxy : IInputProxy
    {
        public string GetMaxRange()
        {
            return System.Console.ReadLine();
        }
    }
}