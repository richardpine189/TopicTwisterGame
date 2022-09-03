using System;
using Zenject;
using Core.Match.Interface;

namespace Assets.Scripts.Presenters
{
    public class LoadingGamePresenter : IInitializable, IDisposable
    {
        [Inject]
        private ILoadingGameView _view;

        [Inject]
        private IGetCurrentMatchUseCase _getMatch;

        [Inject]
        private IActiveMatch _matchActions;

        private string _challengerName;
        private string _opponentName;
        private int _matchId = -1;
        private const int ITS_NEW_MATCH= -1;

        public void Initialize()
        {
            //Inicializar USERNAME
            
            _challengerName = UserDTO.PlayerName;
            
            //Inicializar MatchId
                
            RequestMatchData();
            
            _view.SetPlayersInfoInView(_challengerName, _opponentName);

            _view.OnReadyForNext += SelectSectionAtStart;
            
            _view.StartAnimation(_matchId == ITS_NEW_MATCH);
        }

        public void Dispose()
        {
            _view.OnReadyForNext -= SelectSectionAtStart;
        }
    
        private async void RequestMatchData()
        {
            if (_matchActions.Match == null)
            {
                _matchActions.Match = new Match();
                _matchActions.Match.idMatch = ITS_NEW_MATCH;
                _matchActions.Match.challengerName = _challengerName;
                var matchDto = await _getMatch.Invoke(_challengerName);
                _opponentName = matchDto.opponentName;
                _matchActions.Match.idMatch = matchDto.idMatch;
                _matchActions.Match.challengerName = matchDto.challengerName;
                _matchActions.Match.opponentName = matchDto.opponentName;
                _matchActions.Match.currentRound = matchDto.currentRound;
                _matchActions.Match.isChallengerTurn = matchDto.isChallengerTurn;
                _matchActions.Match.isMatchFinished = matchDto.isMatchFinished;
            }
            else
            {
                var activematch = await _getMatch.Invoke(_matchActions.Match.idMatch);
                _opponentName = activematch.opponentName;
                _matchActions.Match.challengerName = activematch.challengerName;
                _matchActions.Match.opponentName = activematch.opponentName;
                _matchActions.Match.currentRound = activematch.currentRound;
                _matchActions.Match.currentCategories = activematch.currentCategories;
                _matchActions.Match.currentLetter = activematch.currentLetter;
                _matchActions.Match.roundTimeLeft = activematch.currentTime;
                
            }

        }

        private void SelectSectionAtStart()
        {
            if (_matchId == ITS_NEW_MATCH)
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
