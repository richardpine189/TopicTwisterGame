using Models.DTO;
using System;
using Zenject;

public class EndRoundPresenter
{
    private readonly IEndRoundView _endRoundView;
    private readonly IGetRoundResult _getRoundResultUseCase;
    private IGetMatchData _getMatchData;
    private int _matchId;
    private const int LAST_ROUND = 2;

    public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase, IGetMatchData getMatchData)
    {
        _getRoundResultUseCase = getRoundResultUseCase;
        _getMatchData = getMatchData;
        _endRoundView = endRoundView;
        _endRoundView.OnSetRoundResults += RequestRoundResult;
    }

    ~EndRoundPresenter()
    {
        _endRoundView.OnSetRoundResults -= RequestRoundResult;
    }

    private async void RequestRoundResult()
    {
        int roundNumber = _getMatchData.GetRoundNumber();
        MatchResultsDTO matchResultsDTO = await _getRoundResultUseCase.Execute(_matchId);

        if (roundNumber == LAST_ROUND && matchResultsDTO.matchStatus != WinnerStatus.Unassigned)
        {
            _endRoundView.ShowEndGamePanel(matchResultsDTO.matchStatus);
        }

        ShowResultsInView(matchResultsDTO);
    }

    

    private void ShowResultsInView(MatchResultsDTO matchResultsDTO)
    {
        _endRoundView.ShowCategories(matchResultsDTO.currentCategories);
        _endRoundView.ShowChallengerAnswersAndResult(matchResultsDTO.challengerAnswers, matchResultsDTO.challengerResults);
        _endRoundView.ShowOponentAnswersAndResult(matchResultsDTO.opponentAnswers, matchResultsDTO.opponentResults);
    }
}