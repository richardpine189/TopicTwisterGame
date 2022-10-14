using Zenject;

class SaveRoundDataInMemory : ISaveRoundData
{
    IActiveMatch _matchUseCase;

    public SaveRoundDataInMemory(IActiveMatch matchUseCase)
    {
        _matchUseCase = matchUseCase;
    }

    public void SaveLetter(char letter)
    {
        _matchUseCase.Match.round.CurrentLetter = letter;
    }

    public void SaveCurrentCategories(string[] categories)
    {
        _matchUseCase.Match.round.CurrentCategories = categories;
    }

    public void SaveCurrentAnswers(string[] answers)
    {
        _matchUseCase.Match.round.CurrentAnswers = answers;
    }

    public void SaveCurrentResults(bool[] results)
    {
        _matchUseCase.Match.round.CurrentResults = results;
    }

    public void SaveCurrentTime(int time)
    {
        _matchUseCase.Match.round.RoundTimeLeft = time;
    }
    
    

    
}

class SaveMatchDataInMemory : ISaveMatchData
{
    [Inject] IActiveMatch _matchUseCase;
    public void SaveIDMatch(int matchId)
    {
        _matchUseCase.Match.idMatch = matchId;
    }

    public void SavePlayerName(string challenger, string opponent)
    {
        _matchUseCase.Match.challengerName = challenger;
        _matchUseCase.Match.opponentName = opponent;
    }

    public void SaveCurrentRound(int currentRound)
    {
        _matchUseCase.Match.currentRound = currentRound;
    }

    public void SetTurnState(bool isChallengerTurn)
    {
        _matchUseCase.Match.isChallengerTurn = isChallengerTurn;
    }
    public void SetMatchState(bool isMatchFinished)
    {
        _matchUseCase.Match.isMatchFinished = isMatchFinished;
    }
    
}

public interface ISaveMatchData
{
    void SavePlayerName(string challenger, string opponent);
    void SaveCurrentRound(int currentRound);
    void SetTurnState(bool isChallengerTurn);
    void SetMatchState(bool isMatchFinished);
}

public interface ISaveRoundData
{
    void SaveLetter(char letter);
    void SaveCurrentCategories(string[] categories);
    void SaveCurrentAnswers(string[] answers);
    void SaveCurrentResults(bool[] results);
    void SaveCurrentTime(int time);
}
