namespace MainScene.MatchList.Repository
{
    public interface IMatchIdRepository
    {
        void SaveMatchId(int MatchId);
        int GetMatchId();
    }
}