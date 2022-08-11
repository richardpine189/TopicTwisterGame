using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OngoingMatchPresenter
{
    private IOngoingMatchView _view;

    private int _matchId = 0;

    private bool _isPlayerTurn = true;

    public OngoingMatchPresenter(IOngoingMatchView view, MatchDTO matchDTO)
    {
        _view = view;

        _matchId = matchDTO.idMatch;

        IsPlayerTurn(matchDTO);

        SetViewName(matchDTO);

        _view.SetRoundNumber(matchDTO.currentRound);

        SetViewState(matchDTO);

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

    private void SetViewState(MatchDTO matchDTO)
    {
        if (_isPlayerTurn || matchDTO.isMatchFinished)
        {
            _view.ShowPlayButton();
        }
        else
        {
            _view.ShowWaitingClock();
        }
    }

    /*public void BotResolveRound(int matchId, ICategoriesGetter categoriesGetter)
    {
        SetBotInMatchAction botAction = new SetBotInMatchAction(matchId, categoriesGetter);
        botAction.Execute();
    }
    */
}