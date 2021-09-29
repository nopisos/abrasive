using System;

namespace Logging
{
    public class Pathfinder
    {
        private ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Find(string message)
        {
            _logger.Write(message);
        }
    }
}
