using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GuessingGame.GuessingGameOOP.IO.Console
{
    public class JsonLoader
    {
        private readonly string _path;

        public JsonLoader(string path)
        {
            _path = path;
        }
        public ConsoleMessageContainer GetConsoleMessage()
        {
            using (StreamReader r = new StreamReader(_path))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<ConsoleMessageContainer>(json);
            }
        }
    }
}