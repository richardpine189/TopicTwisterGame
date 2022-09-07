
using Zenject;

public class ResetActiveMatch
{
    [Inject] private IActiveMatch _matchAction;
    
    public void Execute()
    {
        _matchAction.Match.currentCategories = null;
        _matchAction.Match.currentLetter = null;
        _matchAction.Match.currentAnswers = null;
        _matchAction.Match.currentResults = null;
        _matchAction.Match.roundTimeLeft = 60;
    }
}
