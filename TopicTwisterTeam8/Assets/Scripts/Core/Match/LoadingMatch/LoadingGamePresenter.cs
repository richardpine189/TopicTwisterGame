using System;
using System.Threading.Tasks;
using Zenject;
using Core.Match.Interface;
using Models;

namespace Assets.Scripts.Presenters
{
    public class LoadingGamePresenter
    {
        private ILoadingGameView _view;
        private IGetCurrentMatchUseCase _getMatch;
        private IActiveMatch _matchUseCase;
        private IGetMatchId _getMachId;

        private string _challengerName;
        private string _opponentName;
        private int _currentRound;
        private int _matchId = -1;
        private const int ITS_NEW_MATCH= -1;
        private const int FIRST_ROUND = 0;

        public LoadingGamePresenter(ILoadingGameView loadingGameView,IGetCurrentMatchUseCase getMatch, IActiveMatch matchUseCase, IGetMatchId getMatchId)
        {
            _view = loadingGameView;
            _getMatch = getMatch;
            _matchUseCase = matchUseCase;
            _getMachId = getMatchId;
            
            Initialize();
        }
        public async void Initialize()
        {
            //Inicializar USERNAME
            
            _challengerName = UserDTO.PlayerName;

            _matchId = _getMachId.Invoke();
                
            _view.SetChallenger(_challengerName); 
            
            await RequestMatchData();
            
            _view.SetOpponent(_opponentName);

            _view.OnReadyForNext += SelectSectionAtStart;
            
            _view.StartAnimation(_matchId == ITS_NEW_MATCH);
        }

        ~LoadingGamePresenter()
        {
            _view.OnReadyForNext -= SelectSectionAtStart;
        }
    
        private async Task RequestMatchData()
        {
            if (_matchId == ITS_NEW_MATCH)
            {
                _matchUseCase.Match = new Match();
                _matchUseCase.Match.idMatch = ITS_NEW_MATCH;
                _matchUseCase.Match.challengerName = _challengerName;
                var matchDto = await _getMatch.Invoke(_challengerName);
                _opponentName = (matchDto.opponentName == _challengerName ? matchDto.challengerName : matchDto.opponentName);
                _matchUseCase.Match.idMatch = matchDto.idMatch;
                _matchUseCase.Match.challengerName = matchDto.challengerName;
                _matchUseCase.Match.opponentName = matchDto.opponentName;
                _matchUseCase.Match.currentRound = matchDto.currentRound;
                _currentRound = matchDto.currentRound;
                _matchUseCase.Match.isChallengerTurn = matchDto.isChallengerTurn;
                _matchUseCase.Match.isMatchFinished = matchDto.isMatchFinished;
            }
            else
            {
                var activematch = await _getMatch.Invoke(_matchId);
                _matchUseCase.Match = new Match();
                _matchUseCase.Match.idMatch = _matchId;
                _opponentName = (activematch.opponentName == _challengerName ? activematch.challengerName : activematch.opponentName);
                _matchUseCase.Match.challengerName = activematch.challengerName;
                _matchUseCase.Match.opponentName = activematch.opponentName;
                _matchUseCase.Match.currentRound = activematch.currentRound;
                _currentRound = activematch.currentRound;
                _matchUseCase.Match.round.CurrentCategories = activematch.currentCategories;
                _matchUseCase.Match.round.CurrentLetter = activematch.currentLetter;
                _matchUseCase.Match.round.RoundTimeLeft = activematch.currentTime;
            }
        }

        private void SelectSectionAtStart()
        {
            if (_currentRound == FIRST_ROUND)
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
