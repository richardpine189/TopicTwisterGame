using System;
using System.Threading.Tasks;
using Architecture.Match.ActiveMatchRepository;
using Architecture.Match.UseCases.GetCurrentMatch;
using Architecture.Match.UseCases.SaveMatchData;
using Architecture.OnGoingMatch.UseCase;
using Architecture.User.Repository;

namespace Architecture.Match.Panel.LoadingMatch
{
    public class LoadingGamePresenter
    {
        private readonly ILoadingGameView _view;
        private readonly IGetCurrentMatchUseCase _getMatch;
        private readonly IGetMatchId _getMachId;
        private readonly ILocalPlayerDataRepository _userLocalRepository;
        
        private string _playerLogged;
        private string _secondPlayer;
        private int _currentRound;
        private int _matchId = -1;
        private readonly ISaveMatchDataUseCase _saveMatchData;

        private const int ITS_NEW_MATCH= -1;
        private const int FIRST_ROUND = 0;

        public LoadingGamePresenter(ILoadingGameView loadingGameView,IGetCurrentMatchUseCase getMatch,ISaveMatchDataUseCase saveMatchData, IGetMatchId getMatchId, ILocalPlayerDataRepository userLocalRepository)
        {
            _saveMatchData = saveMatchData;
            _userLocalRepository = userLocalRepository;
            _view = loadingGameView;
            _getMatch = getMatch;
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

            _view.OnReadyForPanelSelection += SelectSectionAtStart;
            
            _view.StartAnimation(_matchId == ITS_NEW_MATCH);
        }

        ~LoadingGamePresenter()
        {
            _view.OnReadyForPanelSelection -= SelectSectionAtStart;
        }
        
        private async Task RequestMatchData()
        {
            if (_matchId == ITS_NEW_MATCH)
            {
                try
                {
                    var matchDto = await _getMatch.Invoke(_playerLogged);
                    _currentRound = matchDto.currentRound;
                    _secondPlayer = (matchDto.opponentName == _playerLogged ? matchDto.challengerName : matchDto.opponentName);
                    _saveMatchData.SaveNewMatch(matchDto);
                }
                catch (Exception ex)
                {
                    _view.ShowErrorInPanel(ex.Message);
                }
   
            }
            else
            {
                var activeMatch = await _getMatch.Invoke(_matchId);

                _currentRound = activeMatch.currentRound;
                _secondPlayer = (activeMatch.opponentName == _playerLogged ? activeMatch.challengerName : activeMatch.opponentName);
                
                _saveMatchData.SaveActiveMatch(activeMatch, _matchId);
                
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