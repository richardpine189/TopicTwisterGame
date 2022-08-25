using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HardcodedRoundActions : IMatchAction
{
    private static MatchDTO match;

    public MatchDTO Match {
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

    public void SaveTimeToRound(int timeLeft)
    {
        match.roundTimeLeft = 60 - timeLeft;
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
