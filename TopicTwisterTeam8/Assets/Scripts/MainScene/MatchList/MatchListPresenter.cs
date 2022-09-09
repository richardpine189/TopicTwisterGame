using System.Collections.Generic;
using Models;
using Models.DTO;

public class MatchListPresenter
{
    private ISaveMatchId _saveMatchId;
    
    IMatchListView _view;

    private IGetMatchesInfoUseCase _matchInfoUseCase;
    
    public MatchListPresenter(IMatchListView view, IGetMatchesInfoUseCase matchInfoUseCase, ISaveMatchId saveMatchId)
    {
        _saveMatchId = saveMatchId;
        _view = view;
        _matchInfoUseCase = matchInfoUseCase;
        InitializeOnGoingMatch();
    }

    private async void InitializeOnGoingMatch()
    {
        List<MatchDTO> matches = await _matchInfoUseCase.Execute();

        for (int i = 0; i < matches.Count; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            new OngoingMatchPresenter(matchCard, matches[i], _saveMatchId);
        }
    }
}

