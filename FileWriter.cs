using System.IO;

namespace Logging
{
    public class FileWriter : ILogger
    {
        public void Write(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }
}
