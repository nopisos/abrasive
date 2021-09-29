using System;

namespace GameLobby
{
    public class Player
    {
        private Game _game;
        public Room _room;

        public Player(string name, Game game)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name;
        }

        public event Action<PlayerReadyState> StateChanged;
        public event Action<Player> RoomAbandoned;
        public string Name { get; private set; }
        public PlayerReadyState State { get; private set; }

        public void CreateRoom(string name, int maxCapacity, int maxReadyPlayers)
        {
            _game.CreateRoom(name, maxCapacity, maxReadyPlayers);
        }

        public void TryJoinToRoom(Room room)
        {
            if (room == null)
                return;

            if (!room.CanJoin)
                return;

            LeaveRoom();
            room.AddPlayer(this);
            _room = room;            
        }

        public void LeaveRoom()
        {
            RoomAbandoned?.Invoke(this);
            _room = null;
        }

        public void TrySendMessage(string message)
        {
            _room.TrySendMessage(this, message);
        }

        public void ChangeState(PlayerReadyState state)
        {
            State = state;
            StateChanged?.Invoke(state);
        }
    }
}