using Zenject;

class SaveMatchData : ISaveMatchDataUseCase
{
    [Inject] IActiveMatchRepository _matchRepositoryUseCase;
    public void SaveIDMatch(int matchId)
    {
        _matchRepositoryUseCase.Match.idMatch = matchId;
    }

    public void SavePlayerName(string challenger, string opponent)
    {
        _matchRepositoryUseCase.Match.challengerName = challenger;
        _matchRepositoryUseCase.Match.opponentName = opponent;
    }

    public void SaveCurrentRound(int currentRound)
    {
        _matchRepositoryUseCase.Match.currentRound = currentRound;
    }

    public void SetTurnState(bool isChallengerTurn)
    {
        _matchRepositoryUseCase.Match.isChallengerTurn = isChallengerTurn;
    }
    public void SetMatchState(bool isMatchFinished)
    {
        _matchRepositoryUseCase.Match.isMatchFinished = isMatchFinished;
    }
    
}