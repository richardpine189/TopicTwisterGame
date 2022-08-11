using Zenject;

public class MatchListPresenter : IInitializable
{
    IMatchListView _view;

    private IGetMatchesInfo _matchInfo;

    public MatchListPresenter(IMatchListView view, IGetMatchesInfo matchInfo)
    {
        _view = view;
        _matchInfo = matchInfo;
    }

    public void Initialize()
    {
        MatchDTO[] matches = _matchInfo.Execute();

        for (int i = 0; i < matches.Length; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            new OngoingMatchPresenter(matchCard, matches[i]);
        }
    }
}