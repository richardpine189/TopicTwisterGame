using Zenject;

public class EndRoundPresenter
{
    [Inject]
    private IActiveMatch _action;

    private readonly IEndRoundView _endRoundView;
    private readonly IGetRoundResult _getRoundResultUseCase;
    private int _matchId;
    public EndRoundPresenter(IEndRoundView endRoundView, IGetRoundResult getRoundResultUseCase)
    {
        _getRoundResultUseCase = getRoundResultUseCase;
        _endRoundView = endRoundView;
        _endRoundView.OnSetRoundResults += RequestRoundResult;
        
        
        
        //This shouldn't be in the presenter

        /*
        _view.ShowCategories(round.assignedCategoryNames);
        _view.ShowChallengerAnswersAndResult(round.challengerAnswers, round.challengerResult);
        _view.ShowOponentAnswersAndResult(round.opponentAnswers, round.opponentResult);
        */
    }

    ~EndRoundPresenter()
    {
        _endRoundView.OnSetRoundResults -= RequestRoundResult;
    }

    private async void RequestRoundResult()
    {
        await _getRoundResultUseCase.Execute(_matchId);
        //Set In UI
    }
}