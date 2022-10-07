using Zenject;

class GetRoundDataInMemory : IGetRoundData
{
    [Inject] private IActiveMatch _activeMatch;

    public string[] GetCurrentCategories()
    {
        return _activeMatch.Match.round.CurrentCategories;
    }

    public char? GetCurrentLetter()
    {
        return _activeMatch.Match.round.CurrentLetter;
    }

    public string[] GetCurrentAnswers()
    {
        return _activeMatch.Match.round.CurrentAnswers;
    }

    public bool[] GetCurrentResults()
    {
        return _activeMatch.Match.round.CurrentResults;
    }

    public int GetCurrentTime()
    {
        return _activeMatch.Match.round.RoundTimeLeft;
    }
}

class GetMatchDataInMemory : IGetMatchData
{
    [Inject] private IActiveMatch _activeMatch;

    public string GetChallengerName()
    {
        return _activeMatch.Match.challengerName;
    }

    public string GetOpponentName()
    {
        return _activeMatch.Match.opponentName;
    }

    public int GetRoundNumber()
    {
        return _activeMatch.Match.currentRound;
    }
}

public interface IGetMatchData
{
    string GetChallengerName();
    string GetOpponentName();
    int GetRoundNumber();
}

public interface IGetRoundData
{
    string[] GetCurrentCategories();
    char? GetCurrentLetter();
    string[] GetCurrentAnswers();
    bool[] GetCurrentResults();
    int GetCurrentTime();

}