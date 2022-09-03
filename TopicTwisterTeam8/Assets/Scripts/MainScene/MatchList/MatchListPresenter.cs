using System.Collections.Generic;
using Models;
using Zenject;

public class MatchListPresenter : IInitializable
{
    IMatchListView _view;

    private IGetMatchesInfoUseCase _matchInfoUseCase;
    
    public MatchListPresenter(IMatchListView view, IGetMatchesInfoUseCase matchInfoUseCase)
    {
        _view = view;
        _matchInfoUseCase = matchInfoUseCase;
    }

    public async void Initialize()
    {
        List<MatchDTO> matches = await _matchInfoUseCase.Execute();

        for (int i = 0; i < matches.Count; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            new OngoingMatchPresenter(matchCard, matches[i]);
        }
    }
}