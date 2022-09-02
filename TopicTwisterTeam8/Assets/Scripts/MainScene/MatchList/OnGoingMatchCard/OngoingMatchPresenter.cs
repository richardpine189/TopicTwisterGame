using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public class OngoingMatchPresenter
{
    private IOngoingMatchView _view;

    private int _matchId = 0;

    private bool _isPlayerTurn = true;

    public OngoingMatchPresenter(IOngoingMatchView view, MatchDTO match)
    {
        _view = view;

        _matchId = match.idMatch;

        IsPlayerTurn(match);

        SetViewName(match);

        _view.SetRoundNumber(match.currentRound+1); // SACAR MAGIC NUMBER

        SetViewState(match);

        SetRoundsWinnerCounterInUI(match.roundResults);
            
        _view.OnStartMatch += SaveCurrentMatch;
    }

    ~OngoingMatchPresenter()
    {
        _view.OnStartMatch -= SaveCurrentMatch;
    }

    public void SaveCurrentMatch()
    {
        SetActiveMatch action = new SetActiveMatch();
        action.Execute(_matchId);
    }

    private void IsPlayerTurn(MatchDTO match)
    {
        _isPlayerTurn = (match.isChallengerTurn && UserDTO.PlayerName == match.challengerName) || (!match.isChallengerTurn && UserDTO.PlayerName == match.opponentName);
    }

    private void SetViewName(MatchDTO match)
    {
        if(UserDTO.PlayerName == match.challengerName)
        {
            _view.SetOpponentName(match.opponentName);
        }
        else
        {
            _view.SetOpponentName(match.challengerName);
        }
    }

    private void SetViewState(MatchDTO match)
    {
        if (_isPlayerTurn || match.isMatchFinished)
        {
            _view.ShowPlayButton();
        }
        else
        {
            _view.ShowWaitingClock();
        }
    }

    private void SetRoundsWinnerCounterInUI(WinnerStatus[] winner)
    {
        int[] winnerCount = new int[2] {0,0};
        foreach (var w in winner)
        {
            if (w == WinnerStatus.Challenger)
                winnerCount[0]++;
            else if (w == WinnerStatus.Opponent)
                winnerCount[1]++;
            else if (w == WinnerStatus.Draw)
            {
                winnerCount[0]++;
                winnerCount[1]++;
            }
        }
        
        string formatingScore = winnerCount[0] + " - " + winnerCount[1];

        _view.SetRoundCount(formatingScore);
    }
}