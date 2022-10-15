using System.Threading.Tasks;
using Architecture.Match.ActiveMatchRepository;
using Architecture.Match.UseCases.GetCurrentMatch;
using Architecture.OnGoingMatch.UseCase;
using Architecture.User.Repository;

namespace Architecture.Match.Panel.LoadingMatch
{
    public class LoadingGamePresenter
    {
        private readonly ILoadingGameView _view;
        private readonly IGetCurrentMatchUseCase _getMatch;
        private readonly IActiveMatchRepository _matchRepositoryUseCase;
        private readonly IGetMatchId _getMachId;
        private readonly ILocalPlayerDataRepository _userLocalRepository;
        
        private string _playerLogged;
        private string _secondPlayer;
        private int _currentRound;
        private int _matchId = -1;
        
        private const int ITS_NEW_MATCH= -1;
        private const int FIRST_ROUND = 0;

        public LoadingGamePresenter(ILoadingGameView loadingGameView,IGetCurrentMatchUseCase getMatch, IActiveMatchRepository matchRepositoryUseCase, IGetMatchId getMatchId, ILocalPlayerDataRepository userLocalRepository)
        {
            _userLocalRepository = userLocalRepository;
            _view = loadingGameView;
            _getMatch = getMatch;
            _matchRepositoryUseCase = matchRepositoryUseCase;
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
                
                _matchRepositoryUseCase.Match = new Domain.Match();
                _matchRepositoryUseCase.Match.idMatch = matchDto.idMatch;
                _matchRepositoryUseCase.Match.challengerName = matchDto.challengerName;
                _matchRepositoryUseCase.Match.opponentName = matchDto.opponentName;
                _matchRepositoryUseCase.Match.currentRound = matchDto.currentRound;
                _matchRepositoryUseCase.Match.isChallengerTurn = matchDto.isChallengerTurn;
                _matchRepositoryUseCase.Match.isMatchFinished = matchDto.isMatchFinished;
            }
            else
            {
                var activematch = await _getMatch.Invoke(_matchId);

                _currentRound = activematch.currentRound;
                _secondPlayer = (activematch.opponentName == _playerLogged ? activematch.challengerName : activematch.opponentName);
                
                _matchRepositoryUseCase.Match = new Domain.Match();
                _matchRepositoryUseCase.Match.idMatch = _matchId;
                _matchRepositoryUseCase.Match.challengerName = activematch.challengerName;
                _matchRepositoryUseCase.Match.opponentName = activematch.opponentName;
                _matchRepositoryUseCase.Match.currentRound = activematch.currentRound;
                _matchRepositoryUseCase.Match.round.CurrentCategories = activematch.currentCategories;
                _matchRepositoryUseCase.Match.round.CurrentLetter = activematch.currentLetter;
                _matchRepositoryUseCase.Match.round.RoundTimeLeft = activematch.currentTime;
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