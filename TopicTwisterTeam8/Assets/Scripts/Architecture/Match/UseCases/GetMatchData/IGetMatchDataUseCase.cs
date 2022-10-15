namespace Architecture.Match.UseCases.GetMatchData
{
    public interface IGetMatchDataUseCase
    {
        string GetChallengerName();
        string GetOpponentName();
        int GetRoundNumber();
    }
}