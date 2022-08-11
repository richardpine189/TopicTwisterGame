public class EndRoundPresenter
{
    private IEndRoundView _view;
    private IMatchAction _action;

    public EndRoundPresenter(IEndRoundView endRoundView)
    {
        _view = endRoundView;
        _action = new HardcodedMatchActions();
        _action.GetMatch();
        int roundIndex = 0;

        if (_action.IsFinished())
        {
            bool playerWon = (_action.ChallengerWon() && _action.GetMatch().challenger.UserName == UserDTO.PlayerName) || (!_action.ChallengerWon() && _action.GetMatch().opponent.UserName == UserDTO.PlayerName);

            _view.ShowEndGamePanel(playerWon);
        }

        roundIndex = _action.GetCurrentRoundIndex() - 1;

        //This shouldn't be in the presenter
        Match match = _action.GetMatch();
        Round round = match.rounds[roundIndex];

        _view.ShowCategories(round.assignedCategoryNames);
        _view.ShowChallengerAnswersAndResult(round.challengerAnswers, round.challengerResult);
        _view.ShowOponentAnswersAndResult(round.opponentAnswers, round.opponentResult);
    }
}

