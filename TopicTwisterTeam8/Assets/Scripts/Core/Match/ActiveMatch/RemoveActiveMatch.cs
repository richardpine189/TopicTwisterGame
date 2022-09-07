using Zenject;

public class RemoveActiveMatch
{
    [Inject] private IActiveMatch _matchAction;
    public void Execute()
    {
        _matchAction.Match = null;
    }
}
