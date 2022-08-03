using Zenject;

public class MatchListPresenter : IInitializable
{
    [Inject]
    IMatchListView _view;

    [Inject]
    private IGetMatchesInfo _matchInfo;

    public void Initialize()
    {
        MatchDTO[] matches = _matchInfo.Execute();

        for (int i = 0; i < matches.Length; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            OngoingMatchPresenter matchPresenter = new OngoingMatchPresenter(matchCard, matches[i]);
        }
    }
}