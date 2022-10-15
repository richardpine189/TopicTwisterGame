namespace Architecture.OnGoingMatch.Repository
{
    public interface IMatchIdRepository
    {
        void SaveMatchId(int MatchId);
        int GetMatchId();
    }
}