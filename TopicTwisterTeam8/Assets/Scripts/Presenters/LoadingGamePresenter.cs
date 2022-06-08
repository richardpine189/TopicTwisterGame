using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Presenters
{
    public class LoadingGamePresenter
    {
        private ILoadingGameView _view;
        private IMatchAction _matchActions;

        // The matchcreator must come by dependency injection if the only class to access this constructor is the view?
        // Should matchCreator and matchInfo be the same entity if both deal with match responsabilities?
        public LoadingGamePresenter(ILoadingGameView view, IMatchAction matchActions)
        {
            _view = view;
            _matchActions = matchActions;
            _matchActions.CreateMatch();

            string playerName = _matchActions.GetPlayerName();
            string opponentName = _matchActions.GetOpponentName();

            _view.ShowPlayersInfo(playerName, opponentName);
        }
    }
}
