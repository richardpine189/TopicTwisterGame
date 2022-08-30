using System.Collections.Generic;
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

    public async void Initialize()
    {
        List<MatchDTO> matches = await _matchInfo.Execute();

        for (int i = 0; i < matches.Count; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            new OngoingMatchPresenter(matchCard, matches[i]);
        }
    }
}