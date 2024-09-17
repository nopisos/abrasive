using System.Collections.Generic;

namespace GameLobby
{
    public class Game
    {
        private List<Room> _rooms = new List<Room>();
        public IReadOnlyList<Room> Rooms => _rooms;

        public void CreateRoom(string name, int maxCapacity, int maxReadyPlayers)
        {
            Room newRoom = new Room(name, maxCapacity, maxReadyPlayers);
            _rooms.Add(newRoom);
        }         
    }    
}