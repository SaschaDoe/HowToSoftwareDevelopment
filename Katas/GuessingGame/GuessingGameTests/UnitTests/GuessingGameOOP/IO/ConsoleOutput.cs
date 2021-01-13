using System;
using System.IO;

namespace GuessingGameTests.UnitTests.GuessingGameOOP.IO
{
    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;
 
        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }
 
        public string GetOutput()
        {
            return _stringWriter.ToString();
        }
 
        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}