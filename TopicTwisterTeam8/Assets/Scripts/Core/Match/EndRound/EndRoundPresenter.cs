using Zenject;

public class EndRoundPresenter
{
    [Inject]
    private IActiveMatch _action;

    private IEndRoundView _view;

    public EndRoundPresenter(IEndRoundView endRoundView)
    {
        _view = endRoundView;

        //This shouldn't be in the presenter
        
        /*
        _view.ShowCategories(round.assignedCategoryNames);
        _view.ShowChallengerAnswersAndResult(round.challengerAnswers, round.challengerResult);
        _view.ShowOponentAnswersAndResult(round.opponentAnswers, round.opponentResult);
        */
    }
}

