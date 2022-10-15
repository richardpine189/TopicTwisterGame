using System.Collections.Generic;
using Models.DTO;

public class MatchListPresenter
{
    private readonly ISaveMatchId _saveMatchId;
    private readonly IMatchListView _view;
    private readonly IGetMatchesInfoUseCase _matchInfoUseCase;
    private readonly ILocalPlayerDataRepository _playerDataRepository;

    public MatchListPresenter(IMatchListView view, IGetMatchesInfoUseCase matchInfoUseCase, ISaveMatchId saveMatchId, ILocalPlayerDataRepository playerDataRepository)
    {
        _saveMatchId = saveMatchId;
        _view = view;
        _matchInfoUseCase = matchInfoUseCase;
        _playerDataRepository = playerDataRepository;
        InitializeOnGoingMatch();
    }

    private async void InitializeOnGoingMatch()
    {
        List<MatchDTO> matches = await _matchInfoUseCase.Execute();

        for (int i = 0; i < matches.Count; i++)
        {
            IOngoingMatchView matchCard = _view.CreateMatchCard();
            new OngoingMatchPresenter(matchCard, matches[i], _saveMatchId, _playerDataRepository);
        }
    }
}

