using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HardcodedMatchActions : IMatchAction
{
    private User _player;
    private User _opponent;
    private ImBot _newBoot;
    Match match;
    private ICurrentMatchService _matchService;

    public HardcodedMatchActions()
    {
        _matchService = ServiceLocator.Instance.GetService<ICurrentMatchService>();
    }

    public void CreateMatch()
    {
        FindPlayers();

        match = new Match();
        match.challenger = new User(1, "Ricardo");
        match.opponent = new User(2, "Theo");

        match.rounds[0] = new Round();

        _matchService.SetActiveMatch(match);
    }

    public void FindPlayers()
    {
        _player = new User(1, "Ricardo");
        _opponent = new User(2, "Theo");
    }

    public string GetPlayerName()
    {
        return _matchService.GetActiveMatch().challenger.UserName;
    }

    public string GetOpponentName()
    {
        return _matchService.GetActiveMatch().opponent.UserName;
    }

    public Match GetMatch()
    {
        if (CheckActiveMatch())
        {
            match = _matchService.GetActiveMatch();
        }
        else
        {
            CreateMatch();
        }

        return match;
    }

    #region Other_Class
    // These methods should be in a separate action class responsible of multiple verifications of a Match instance. The methods should receive a Match by parameter.
    
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
        if (!match.rounds.Any(x => x == null) && match.rounds.All(x => x.roundFinished))
        {
            return true;
        }

        return false;
    }

    public bool ChallengerWon()
    {
        int wonRoundsCount = 0;

        for(int i = 0; i < match.rounds.Length; i++)
        {
            if(match.rounds[i].challengerResult.Where(x => x == CorrectionStatus.Valid).Count() > match.rounds[i].opponentResult.Where(x => x == CorrectionStatus.Valid).Count())
            {
                wonRoundsCount += 1;
            }
        }

        if(wonRoundsCount > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckActiveMatch()
    {
        return (_matchService.GetActiveMatch() != null);
    }

    public bool IsChallengerTurn()
    {
        return (CheckActiveMatch() && GetCurrentRound().opponentAnswers == null);
    }

    public void SaveTimeToRound(int timeLeft)
    {
        Round round = GetCurrentRound();
        round.timer = timeLeft;
    }

    public int GetTimeToAnswer()
    {
        Round round = GetCurrentRound();

        if(round.timer < 50)
        {
            return round.timer + 10;
        }

        return round.timer;
    }

    #endregion
}

