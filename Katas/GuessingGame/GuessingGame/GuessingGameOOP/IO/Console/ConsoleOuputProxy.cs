using System.Collections.Generic;
using System.Linq;

namespace GuessingGame.GuessingGameOOP.IO.Console
{
    public class ConsoleOuputProxy : IOutputProxy
    {
        private const string GermanConsoleOutputJson = "Resources/GermanConsoleOutput.json";
        private readonly ConsoleMessageContainer _consoleMessageContainer;
        public ConsoleOuputProxy()
        {
            var loader = new JsonLoader(GermanConsoleOutputJson);
            _consoleMessageContainer = loader.GetConsoleMessage();
        }
        
        public void Show(GuessResult guessResult)
        {
            throw new System.NotImplementedException();
        }

        public void ShowStartMessage()
        {
            System.Console.WriteLine(_consoleMessageContainer.StartGameMessage);
        }

        public void ShowNewRound()
        {
            throw new System.NotImplementedException();
        }

        public void ShowWinningMessage()
        {
            throw new System.NotImplementedException();
        }

        public void ShowGreater()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSmaller()
        {
            throw new System.NotImplementedException();
        }

        public void ShowEnterMaxRangeMessage()
        {
            System.Console.Write(_consoleMessageContainer.EnterMaxRangeMessage);
        }

        public string GetMaxRange()
        {
            return System.Console.ReadLine();
        }
    }
}