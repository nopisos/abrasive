using System.Collections.Generic;

namespace GameLobby
{
    public class Chat
    {
        private List<string> _chatLog = new List<string>();

        public void Send(string message)
        {
            _chatLog.Add(message);
        }
    }
}