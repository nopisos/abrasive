using System;

namespace Logging
{
    public class ConsoleWriterDecorator : ILogger
    {
        private ILogger _logger;

        public ConsoleWriterDecorator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Write(string message)
        {
            Console.WriteLine(message);
            _logger.Write(message);
        }
    }
}
