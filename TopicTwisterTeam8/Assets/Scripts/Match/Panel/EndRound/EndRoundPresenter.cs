using Models.DTO;
using System;
using Zenject;

public class EndRoundPresenter
{
    private readonly IEndRoundView _endRoundView;
    private readonly IGetRoundResult _getRoundResultUseCase;
    private readonly ILocalPlayerDataRepository _userLocalRepository;
    private IGetMatchId _getMachId;
    private IGetMatchDataUseCase _getMatchDataUseCase;
    private const int LAST_ROUND = 2;

    public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase, IGetMatchDataUseCase getMatchDataUseCase, IGetMatchId getMatchId, ILocalPlayerDataRepository userLocalRepository)
    {
        _getRoundResultUseCase = getRoundResultUseCase;
        _getMachId = getMatchId;
        _getMatchDataUseCase = getMatchDataUseCase;
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