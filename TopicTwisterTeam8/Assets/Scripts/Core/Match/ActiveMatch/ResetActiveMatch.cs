
using Zenject;

public class ResetActiveMatch
{
    [Inject] private IActiveMatch _matchAction;
    
    public void Execute()
    {
        _matchAction.Match.round.CurrentCategories = null;
        _matchAction.Match.round.CurrentLetter = null;
        _matchAction.Match.round.CurrentAnswers = null;
        _matchAction.Match.round.CurrentResults = null;
        _matchAction.Match.round.RoundTimeLeft = 60;
    }
}
