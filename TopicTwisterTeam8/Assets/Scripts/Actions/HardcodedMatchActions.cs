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

            Match match = new Match();
            match.challenger = new User(1, "Ricardo");
            match.opponent = new User(2, "Theo");

            _matchService.SetActiveMatch(match);
        }

        public void FindPlayers()
        {
            _player = new User(1, "jugador");
            _opponent = new User(2, "oponente");
        }

        public string GetPlayerName()
        {
            return _matchService.GetActiveMatch().challenger.UserName;
        }

        public string GetOpponentName()
        {
            return _matchService.GetActiveMatch().opponent.UserName;
        }
    }
}
