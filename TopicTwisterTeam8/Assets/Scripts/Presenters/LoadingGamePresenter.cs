using System;
using Zenject;
using Core.Match.Interface;

namespace Assets.Scripts.Presenters
{
    public class LoadingGamePresenter : IInitializable, IDisposable
    {
        [Inject] private ILoadingGameView _view;
        [Inject] private IGetCurrentMatchUseCase _getMatch;
        private string _challengerName = "Theo";
        private string _opponentName;
        private int _matchId = -1;
        private const int ITS_NEW_MATCH= -1;

        private IMatchAction _matchActions;

        public void Initialize()
        {
            //Inicializar USERNAME
            //Inicializar MatchId
            RequestMatchData();

            _matchActions = new HardcodedRoundActions();
            
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
            var matchDto = await _getMatch.Invoke(_matchId, _challengerName);
            _challengerName = matchDto.challengerName;
            _opponentName = matchDto.opponentName;
            _matchActions.Match = new Match();
            _matchActions.Match.idMatch = matchDto.idMatch;
            _matchActions.Match.challengerName = matchDto.challengerName;
            _matchActions.Match.opponentName = matchDto.opponentName;
            _matchActions.Match.currentRound = matchDto.currentRound;
            _matchActions.Match.isChallengerTurn = matchDto.isChallengerTurn;
            _matchActions.Match.isMatchFinished = matchDto.isMatchFinished;
            
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
