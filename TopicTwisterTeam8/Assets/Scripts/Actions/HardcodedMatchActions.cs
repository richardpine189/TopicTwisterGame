using Assets.Scripts.Interfaces;
using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Actions
{
    public class HardcodedMatchActions : IMatchAction
    {
        private User _player;
        private User _opponent;

        private ICurrentMatchService _matchService;

        public HardcodedMatchActions()
        {
            _matchService = new SingletonCurrentMatchService();
        }

        public void CreateMatch()
        {
            FindPlayers();

            _matchService.Save(new Match(_player, _opponent));
        }

        public void FindPlayers()
        {
            _player = new User(1, "jugador");
            _opponent = new User(2, "oponente");
        }

        public string GetPlayerName()
        {
            return _matchService.Get().Player.UserName;
        }

        public string GetOpponentName()
        {
            return _matchService.Get().Opponent.UserName;
        }
    }
}
