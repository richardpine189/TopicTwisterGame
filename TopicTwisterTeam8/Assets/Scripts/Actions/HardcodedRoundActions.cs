using System;

public class HardcodedRoundActions : IMatchAction
{
    private static Match match;

    public Match Match {
        get
        {
            return match;
        }
        set
        {
            match = value;
        }
    }

    public int GetCurrentRoundIndex()
    {
        return match.currentRound;
    }

    public bool IsFinished()
    {
        throw new NotImplementedException();
    }

    //USECASE TIME
    public void SaveTimeToRound(int timeLeft)
    {
        match.roundTimeLeft = 60 - timeLeft;
        UnityEngine.Debug.Log(match.roundTimeLeft);
    }

    public int GetTimeToAnswer()
    {
        int timeLeft = match.roundTimeLeft;
        
        if(timeLeft < 10)
        {
            return timeLeft + 10;
        }
        
        return timeLeft;
    }
}
