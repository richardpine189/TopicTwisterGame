using System;
using System.Threading.Tasks;
using Zenject;
using Core.Match.Interface;
using Models;

namespace Assets.Scripts.Presenters
{
    public class LoadingGamePresenter
    {
        private readonly ILoadingGameView _view;
        private readonly IGetCurrentMatchUseCase _getMatch;
        private readonly IActiveMatch _matchUseCase;
        private readonly IGetMatchId _getMachId;
        private readonly ILocalPlayerDataRepository _userLocalRepository;
        
        private string _playerLogged;
        private string _secondPlayer;
        private int _currentRound;
        private int _matchId = -1;
        
        private const int ITS_NEW_MATCH= -1;
        private const int FIRST_ROUND = 0;

        public LoadingGamePresenter(ILoadingGameView loadingGameView,IGetCurrentMatchUseCase getMatch, IActiveMatch matchUseCase, IGetMatchId getMatchId, ILocalPlayerDataRepository userLocalRepository)
        {
            _userLocalRepository = userLocalRepository;
            _view = loadingGameView;
            _getMatch = getMatch;
            _matchUseCase = matchUseCase;
            _getMachId = getMatchId;
            
            Initialize();
        }
        public async void Initialize()
        {
            _matchId = _getMachId.Invoke();
            _playerLogged = _userLocalRepository.GetData().name;
            _view.SetChallenger(_playerLogged); 
            
            await RequestMatchData();
            
            _view.SetOpponent(_secondPlayer);

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
                var matchDto = await _getMatch.Invoke(_playerLogged);

                _currentRound = matchDto.currentRound;
                _secondPlayer = (matchDto.opponentName == _playerLogged ? matchDto.challengerName : matchDto.opponentName);
                
                _matchUseCase.Match = new Match();
                _matchUseCase.Match.idMatch = matchDto.idMatch;
                _matchUseCase.Match.challengerName = matchDto.challengerName;
                _matchUseCase.Match.opponentName = matchDto.opponentName;
                _matchUseCase.Match.currentRound = matchDto.currentRound;
                _matchUseCase.Match.isChallengerTurn = matchDto.isChallengerTurn;
                _matchUseCase.Match.isMatchFinished = matchDto.isMatchFinished;
            }
            else
            {
                var activematch = await _getMatch.Invoke(_matchId);

                _currentRound = activematch.currentRound;
                _secondPlayer = (activematch.opponentName == _playerLogged ? activematch.challengerName : activematch.opponentName);
                
                _matchUseCase.Match = new Match();
                _matchUseCase.Match.idMatch = _matchId;
                _matchUseCase.Match.challengerName = activematch.challengerName;
                _matchUseCase.Match.opponentName = activematch.opponentName;
                _matchUseCase.Match.currentRound = activematch.currentRound;
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