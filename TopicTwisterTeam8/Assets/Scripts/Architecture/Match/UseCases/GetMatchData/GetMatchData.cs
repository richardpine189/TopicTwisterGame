using Zenject;

class GetMatchData : IGetMatchDataUseCase
{
    [Inject] private IActiveMatchRepository _activeMatchRepository;

    public string GetChallengerName()
    {
        return _activeMatchRepository.Match.challengerName;
    }

    public string GetOpponentName()
    {
        return _activeMatchRepository.Match.opponentName;
    }

    public int GetRoundNumber()
    {
        return _activeMatchRepository.Match.currentRound;
    }
}
