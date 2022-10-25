using Architecture.Match.Domain.DTO;
using Architecture.Match.Panel.EndRound.GetRoundResults;
using Architecture.Match.UseCases.GetMatchData;
using Architecture.Match.UseCases.GetRoundData;
using Architecture.Match.UseCases.SaveMatchData;
using Architecture.Match.UseCases.SaveRoundData;
using Architecture.OnGoingMatch.UseCase;
using Architecture.User.Repository;

namespace Architecture.Match.Panel.EndRound
{
    public class EndRoundPresenter
    {
        private readonly IEndRoundView _endRoundView;
        private readonly IGetRoundResult _getRoundResultUseCase;
        private readonly ILocalPlayerDataRepository _userLocalRepository;
        private IGetMatchId _getMachId;
        private IGetMatchDataUseCase _getMatchDataUseCase;
        private readonly ISaveRoundDataUseCase _saveRoundData;
        private readonly IGetRoundDataUseCase _getRoundData;
        private readonly ISaveMatchDataUseCase _saveMatchData;
        private const int LAST_ROUND = 2;

        public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase, IGetMatchDataUseCase getMatchDataUseCase, ISaveMatchDataUseCase saveMatchData, IGetMatchId getMatchId, ISaveRoundDataUseCase saveRoundData, IGetRoundDataUseCase getRoundData, ILocalPlayerDataRepository userLocalRepository)
        {
            _getRoundResultUseCase = getRoundResultUseCase;
            _saveRoundData = saveRoundData;
            _getRoundData = getRoundData;
            _getMachId = getMatchId;
            _getMatchDataUseCase = getMatchDataUseCase;
            _saveMatchData = saveMatchData;
            
            _endRoundView = endRoundView;
            _userLocalRepository = userLocalRepository;
            _endRoundView.OnSetRoundResults += RequestRoundResult;
        }

        ~EndRoundPresenter()
        {
            _endRoundView.OnSetRoundResults -= RequestRoundResult;
        }

        private async void RequestRoundResult()
        {
            int roundNumber = _getMatchDataUseCase.GetRoundNumber();
            int _matchId = _getMachId.Invoke();
            RoundResultsDTO roundResultsDto = await _getRoundResultUseCase.Execute(_matchId);
            
            //Synchronize Letter
            char previewsRoundLetter = roundResultsDto.letter;
            char currentRoundLetter = _getRoundData.GetCurrentLetter();
            
            //Synchronize RoundNumber
            int previewsRoundNumber = roundResultsDto.roundIndex;
            int currentRoundNumber = _getMatchDataUseCase.GetRoundNumber();
            
            _saveMatchData.SaveCurrentRound(previewsRoundNumber);
            _saveRoundData.SaveLetter(previewsRoundLetter);
            
            _endRoundView.SetLetterForHeader();
            
            _saveRoundData.SaveLetter(currentRoundLetter);
            _saveMatchData.SaveCurrentRound(currentRoundNumber);
                
            if (roundNumber == LAST_ROUND && roundResultsDto.matchStatus != WinnerStatus.Unassigned)
            {
                _endRoundView.ShowEndGamePanel(roundResultsDto.matchStatus);
            }

            ShowResultsInView(roundResultsDto);
        }

        private void ShowResultsInView(RoundResultsDTO roundResultsDto)
        {
            _endRoundView.ShowCategories(roundResultsDto.currentCategories);

            if(_userLocalRepository.GetData().name == _getMatchDataUseCase.GetChallengerName())
            {
                _endRoundView.ShowLoggedPlayerAnswersAndResult(roundResultsDto.challengerAnswers, roundResultsDto.challengerResults);
                _endRoundView.ShowSecondPlayerAnswersAndResult(roundResultsDto.opponentAnswers, roundResultsDto.opponentResults);
            }
            else
            {
                _endRoundView.ShowLoggedPlayerAnswersAndResult(roundResultsDto.opponentAnswers, roundResultsDto.opponentResults);
                _endRoundView.ShowSecondPlayerAnswersAndResult(roundResultsDto.challengerAnswers, roundResultsDto.challengerResults);
            }
        }
    }
}