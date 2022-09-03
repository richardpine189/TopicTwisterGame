using Zenject;

class MatchHasUseCase : IMatchHas
{
    [Inject]
    private IActiveMatch _activeMatch;

    public bool CurrentCategories()
    {
        return _activeMatch.Match.currentCategories != null;
    }
}
