using System;
using System.IO;

namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class ConsoleInput: IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextReader _originalInput;
 
        public ConsoleInput()
        {
            _stringWriter = new StringWriter();
            _originalInput = Console.In;
            Console.SetOut(_stringWriter);
        }
 
        public string GetInput()
        {
            return _stringWriter.ToString();
        }
 
        public void Dispose()
        {
            Console.SetIn(_originalInput);
            _stringWriter.Dispose();
        }
    }
}