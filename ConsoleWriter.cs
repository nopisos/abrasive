using System;

namespace Logging
{
    public class ConsoleWriter : ILogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
