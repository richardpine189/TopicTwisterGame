public interface ISaveMatchDataUseCase
{
    void SavePlayerName(string challenger, string opponent);
    void SaveCurrentRound(int currentRound);
    void SetTurnState(bool isChallengerTurn);
    void SetMatchState(bool isMatchFinished);
}