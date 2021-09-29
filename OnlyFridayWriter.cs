using System;

namespace Logging
{
    public class OnlyFridayWriter : ILogger
    {
        private ILogger _logger;

        public OnlyFridayWriter(ILogger logger)
        {
            _logger = logger;
        }

        public void Write(string message)
        {
            if(DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logger.Write(message);
            }
        }
    }
}
