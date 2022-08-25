public class EndRoundPresenter
{
    private IEndRoundView _view;
    private IMatchAction _action;

    public EndRoundPresenter(IEndRoundView endRoundView)
    {
        _view = endRoundView;

        int roundIndex = 0;

        

        roundIndex = _action.GetCurrentRoundIndex() - 1;

        //This shouldn't be in the presenter
        
        /*

        _view.ShowCategories(round.assignedCategoryNames);
        _view.ShowChallengerAnswersAndResult(round.challengerAnswers, round.challengerResult);
        _view.ShowOponentAnswersAndResult(round.opponentAnswers, round.opponentResult);
        */
    }
}

