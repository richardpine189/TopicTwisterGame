namespace Models.DTO
{
    public class MatchDTO
    {
        public int idMatch;
        public string challengerName;
        public string opponentName;
        public int currentRound;
        public bool isChallengerTurn;
        public bool isMatchFinished;
        public WinnerStatus[] roundResults = new WinnerStatus[3];
    }

    public enum WinnerStatus
    {
        Unassigned, Challenger, Opponent, Draw
    }
}