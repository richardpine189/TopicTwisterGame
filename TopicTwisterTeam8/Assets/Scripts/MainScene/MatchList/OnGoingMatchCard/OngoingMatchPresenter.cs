using System;
using System.Drawing;
using System.Linq;
using Models.DTO;

public class OngoingMatchPresenter
{
    private IOngoingMatchView _view;

    private ISaveMatchId _saveMatchId;

    private int _matchId = 0;

    private bool _isPlayerTurn = true;

    private int[] winnerCount = new int[2] { 0, 0 };

    private const int OFFSET_FOR_ROUND_COUNTING = 1;

    private readonly Color RED_COLOR = Color.FromArgb(255, 0, 0);
    private readonly Color GREEN_COLOR = Color.FromArgb(53, 164, 52);
    private readonly Color BLUE_COLOR = Color.FromArgb(47, 81, 231);
    private readonly Color YELLOW_COLOR = Color.FromArgb(255, 255, 0);

    public OngoingMatchPresenter(IOngoingMatchView view, MatchDTO match, ISaveMatchId saveMatchId)
    {
        _saveMatchId = saveMatchId;
        _view = view;

        _matchId = match.idMatch;

        IsPlayerTurn(match);

        SetViewName(match);

        _view.SetRoundNumber(match.currentRound + OFFSET_FOR_ROUND_COUNTING);

        SetViewState(match);

        CalculateRoundsWinner(match.matchWinnerStatus);

        SetRoundsWinnerCounter();

        SetBackgroundColor(match);
            
        _view.OnStartMatch += SaveCurrentMatch;
    }

    ~OngoingMatchPresenter()
    {
        _view.OnStartMatch -= SaveCurrentMatch;
    }

    public void SaveCurrentMatch()
    {
        _saveMatchId.Invoke(_matchId);
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
        // Shows clock if match is finished
        if (!match.isMatchFinished && _isPlayerTurn)
        {
            _view.ShowPlayButton();
        }
        else
        {
            _view.ShowWaitingClock();
        }
    }

    private void CalculateRoundsWinner(WinnerStatus[] winner)
    {
        foreach (var w in winner)
        {
            if (w == WinnerStatus.Challenger)
            {
                winnerCount[0]++;
            }
            else if (w == WinnerStatus.Opponent)
            {
                winnerCount[1]++;
            }
            else if (w == WinnerStatus.Draw)
            {
                winnerCount[0]++;
                winnerCount[1]++;
            }
        }
    }

    private void SetRoundsWinnerCounter()
    {
        string formatingScore = winnerCount[0] + " - " + winnerCount[1];

        _view.SetRoundCount(formatingScore);
    }

    private void SetBackgroundColor(MatchDTO match)
    {
        if(!match.isMatchFinished)
        {
            _view.SetCardColor(GREEN_COLOR);
        }
        else
        {
            if(winnerCount[0] > winnerCount[1])
            {
                if (UserDTO.PlayerName == match.challengerName)
                {
                    _view.SetCardColor(BLUE_COLOR);
                }
                else
                {
                    _view.SetCardColor(RED_COLOR);
                }
            }
            else if(winnerCount[0] < winnerCount[1])
            {
                if (UserDTO.PlayerName == match.challengerName)
                {
                    _view.SetCardColor(RED_COLOR);
                }
                else
                {
                    _view.SetCardColor(BLUE_COLOR);
                }
            }
            else
            {
                _view.SetCardColor(YELLOW_COLOR);
            }
        }
    }
}