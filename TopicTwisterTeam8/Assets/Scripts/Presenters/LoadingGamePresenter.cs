using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class LoadingGamePresenter
    {
        private ILoadingGameView _view;
        private IMatchAction _matchActions;
        private bool _isNewGame;
        private string _playerName;
        private string _opponentName;
        // The matchcreator must come by dependency injection if the only class to access this constructor is the view?
        // Should matchCreator and matchInfo be the same entity if both deal with match responsabilities?
        public LoadingGamePresenter(ILoadingGameView view, IMatchAction matchActions)
        {
            _view = view;
            _matchActions = matchActions;

            InitMatchData();
            _view.ShowPlayersInfo(_playerName, _opponentName);
            _view.StartAnimation();
            SelectSectionAtStart();
        }
       
        private void InitMatchData()
        {
            _isNewGame = !_matchActions.CheckActiveMatch();
            _matchActions.GetMatch();
            _playerName = _matchActions.GetPlayerName();
            _opponentName = _matchActions.GetOpponentName();
        }
        private  void SelectSectionAtStart()
        {
            
            if (_isNewGame)
            {
                _view.ShowCategoriesSection();
            }
            else
            {
                
                // HARDCODEADO PARA EL SPRINT REVIEW.... Implementar CurrentRound
                if (_matchActions.GetMatch().rounds[0].opponentAnswers == null)
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

