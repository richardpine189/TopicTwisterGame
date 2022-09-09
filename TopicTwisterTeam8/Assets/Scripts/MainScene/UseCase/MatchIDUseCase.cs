using MainScene.MatchList.Repository;

public class MatchIDUseCase : ISaveMatchId, IGetMatchId
{
    private IMatchIdRepository _matchIdRepository;

    public MatchIDUseCase(IMatchIdRepository matchIdRepository)
    {
        _matchIdRepository = matchIdRepository;
    }

    public void Invoke(int matchID)
    {
        _matchIdRepository.SaveMatchId(matchID);
    }

    public int Invoke()
    {
        return _matchIdRepository.GetMatchId();
    }
}

