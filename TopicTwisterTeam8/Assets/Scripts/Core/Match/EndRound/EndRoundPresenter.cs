﻿using Models.DTO;
using System;
using Zenject;

public class EndRoundPresenter
{
    private readonly IEndRoundView _endRoundView;
    private readonly IGetRoundResult _getRoundResultUseCase;
    private IGetMatchId _getMachId;
    private IGetMatchData _getMatchData;
    private const int LAST_ROUND = 2;

    public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase, IGetMatchData getMatchData, IGetMatchId getMatchId)
    {
        _getRoundResultUseCase = getRoundResultUseCase;
        _getMachId = getMatchId;
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
        int _matchId = _getMachId.Invoke();
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

        if(UserDTO.PlayerName == _getMatchData.GetChallengerName())
        {
            _endRoundView.ShowLoggedPlayerAnswersAndResult(matchResultsDTO.challengerAnswers, matchResultsDTO.challengerResults);
            _endRoundView.ShowSecondPlayerAnswersAndResult(matchResultsDTO.opponentAnswers, matchResultsDTO.opponentResults);
        }
        else
        {
            _endRoundView.ShowLoggedPlayerAnswersAndResult(matchResultsDTO.opponentAnswers, matchResultsDTO.opponentResults);
            _endRoundView.ShowSecondPlayerAnswersAndResult(matchResultsDTO.challengerAnswers, matchResultsDTO.challengerResults);
        }
    }
}