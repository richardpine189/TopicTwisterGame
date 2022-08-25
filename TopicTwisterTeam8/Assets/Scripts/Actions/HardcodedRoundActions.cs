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
    private User _challenger;
    private User _opponent;
    private ImBot _newBoot;
    
    Match match;

    public Match GetMatch()
    {
        return match;
    }
    public Round GetCurrentRound()
    {
        int index = GetCurrentRoundIndex();
        if (match.rounds[index] == null)
        {
            match.rounds[index] = new Round();
        }

        return match.rounds[GetCurrentRoundIndex()];
    }

    public int GetCurrentRoundIndex()
    {
        if (match.rounds.All(x => x == null))
        {
            return 0;
        }

        for (int i = 0; i < match.rounds.Length; i++)
        {
            if (match.rounds[i] == null || !match.rounds[i].roundFinished)
            {
                return i;
            }
        }

        return 3;
    }

    public bool IsFinished()
    {
        throw new NotImplementedException();
    }

    public void SaveTimeToRound(int timeLeft)
    {
        Round round = GetCurrentRound();
        round.timer = 60 - timeLeft;
    }

    public int GetTimeToAnswer()
    {
        Round round = GetCurrentRound();
        
        if(round.timer < 10)
        {
            return round.timer + 10;
        }
        
        return round.timer;
    }
}






