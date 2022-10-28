using Architecture.Match.Domain.DTO;

namespace Architecture.Match.UseCases.SaveMatchData
{
    public interface ISaveMatchDataUseCase
    {
        void SavePlayerName(string challenger, string opponent);
        void SaveCurrentRound(int currentRound);
        void SetTurnState(bool isChallengerTurn);
        void SetMatchState(bool isMatchFinished);
        void SaveNewMatch(MatchDTO matchDto);
        void SaveActiveMatch(ActiveMatchDTO activeMatch, int matchId);
    }
}