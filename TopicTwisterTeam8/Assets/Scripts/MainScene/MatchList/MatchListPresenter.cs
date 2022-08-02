using Zenject;

public class MatchListPresenter : IInitializable
{
    [Inject] IMatchListView _view;
    [Inject] private IGetMatchesInfo _matchInfo;

    public void Initialize()
    {
        MatchViewModel[] matches = _matchInfo.Execute();
        for (int i = 0; i < matches.Length; i++)
        {
            _view.CreateMatchUI(matches[i]);
        }
    }
}