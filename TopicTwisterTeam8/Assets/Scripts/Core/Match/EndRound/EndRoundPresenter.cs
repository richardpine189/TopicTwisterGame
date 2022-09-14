using Models.DTO;
using System;
using Zenject;

public class EndRoundPresenter
{
    private readonly IEndRoundView _endRoundView;
    private readonly IGetRoundResult _getRoundResultUseCase;
    private IGetMatchRoundNumber _getMatchRoundNumberUseCase;
    private int _matchId;

    private static int hasAppeared = 0;

    public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase, IGetMatchRoundNumber getMatchRoundNumber)
    {
        _getRoundResultUseCase = getRoundResultUseCase;
        _getMatchRoundNumberUseCase = getMatchRoundNumber;
        _endRoundView = endRoundView;
        _endRoundView.OnSetRoundResults += RequestRoundResult;
    }

    ~EndRoundPresenter()
    {
        _endRoundView.OnSetRoundResults -= RequestRoundResult;
    }

    private async void RequestRoundResult()
    {
        int roundNumber = _getMatchRoundNumberUseCase.Execute();
        MatchResultsDTO matchResultsDTO = await _getRoundResultUseCase.Execute(_matchId, roundNumber - hasAppeared);

        if(hasAppeared == 0)
        {
            hasAppeared = 1;
        }
        else
        {
            hasAppeared = 0;
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