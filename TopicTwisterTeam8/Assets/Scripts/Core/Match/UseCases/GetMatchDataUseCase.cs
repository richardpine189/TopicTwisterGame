using Zenject;

class GetMatchDataUseCase : IGetMatchCategories
{
    [Inject]
    private IActiveMatch _activeMatch;

    public string[] Execute()
    {
        return _activeMatch.Match.currentCategories;
    }
}
