using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _view.OnReadyForNext += SelectSectionAtStart;
            _view.SetNewGameState(_isNewGame);
            _view.StartAnimation();
            //SelectSectionAtStart();



        }
       ~LoadingGamePresenter()
        {
            _view.OnReadyForNext -= SelectSectionAtStart;
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
            

            if (_isNewGame)
            {
                _view.ShowCategoriesSection();
            }
            else
            {
                if (!_matchActions.IsFinished() && _matchActions.IsChallengerTurn())
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
