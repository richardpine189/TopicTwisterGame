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
        private bool _isNewGame;
        private string _playerName;
        private string _opponentName;

        public LoadingGamePresenter(ILoadingGameView view)
        {
            _view = view;
            _matchActions = new HardcodedMatchActions();

            InitMatchData();
            _view.ShowPlayersInfo(_playerName, _opponentName);
            
            SelectSectionAtStart();
        }
       
        private void InitMatchData()
        {
            _isNewGame = !_matchActions.CheckActiveMatch();
            _matchActions.GetMatch();
            _playerName = _matchActions.GetPlayerName();
            _opponentName = _matchActions.GetOpponentName();
        }

        private void SelectSectionAtStart()
        {
            _view.StartAnimation();

            if (_isNewGame)
            {
                _view.ShowCategoriesSection();
            }
            else
            {
                
                if (_matchActions.IsChallengerTurn())
                {
                    _view.ShowCategoriesSection();
                }
                else
                {
                    _view.ShowEndRoundSection();
                }
            }

        }
    }
}
