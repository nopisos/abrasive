using System;
using System.Collections.Generic;

namespace GameLobby
{
    public class Room
    {
        private List<Player> _players = new List<Player>();
        private Chat _chat;
        private int _maxPlayerCapacity;
        private int _maxReadyPlayers;
        private RoomState _state = RoomState.WaitingForReadyPlayers;

        public Room(string name, int maxPlayerCapacity, int maxReadyPlayers)
        {
            Name = name;
            _maxPlayerCapacity = maxPlayerCapacity;
            _maxReadyPlayers = maxReadyPlayers;
            _chat = new Chat();
        }

        public string Name { get; private set; }
        public bool CanJoin => _players.Count < _maxPlayerCapacity;

        public void AddPlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (_players.Count == _maxPlayerCapacity)
                throw new InvalidOperationException();
                       
            _players.Add(player);
            player.StateChanged += OnPlayerReady;
            player.RoomAbandoned += OnPlayerExit;
        }

        public void TrySendMessage(Player player, string message)
        {
            if (!_players.Contains(player))
                throw new ArgumentException(nameof(player));

            switch (_state)
            {
                case RoomState.InGame:
                    if (player.State == PlayerReadyState.Ready)
                        _chat.Send(message);
                    return;
                case RoomState.WaitingForReadyPlayers:
                    _chat.Send(message);
                    return;
            }
        }

        private void OnPlayerReady(PlayerReadyState state)
        {
            int readyPlayersCount = _players.Count(player => player.State == PlayerReadyState.Ready);

            switch (state)
            {
                case PlayerReadyState.Ready:
                    if (readyPlayersCount >= _maxReadyPlayers)
                        _state = RoomState.InGame;
                    break;
                case PlayerReadyState.NotReady:
                    if (readyPlayersCount < _maxReadyPlayers)
                        _state = RoomState.WaitingForReadyPlayers;
                    break;
            }
        }

        private void OnPlayerExit(Player player)
        {
            _players.Remove(player);
        }
    }
}