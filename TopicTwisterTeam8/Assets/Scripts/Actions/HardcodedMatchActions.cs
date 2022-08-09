using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class HardcodedMatchActions : IMatchAction
{
    private User _challenger;
    private User _opponent;
    private ImBot _newBoot;
    Match match;
    private ICurrentMatchService _matchService;

    public HardcodedMatchActions()
    {
        _matchService = ServiceLocator.Instance.GetService<ICurrentMatchService>();
    }


    #region USECASE CREATE MATCH
    public void CreateMatch()
    {
        FindPlayers();

        match = new Match();
        match.challenger = _challenger;
        match.opponent = _opponent;

        match.rounds[0] = new Round();

        _matchService.SetActiveMatch(match);
    }

    public void FindPlayers()
    {
        var users = new List<User>() { new User(0, "Ricardo"), new User(1, "Theo"), new User(2, "Romina") };

        _challenger = users.First(x => x.UserName == LoggedUserDTO.PlayerName);

        users.Remove(_challenger);

        Random rnd = new Random();

        _opponent = users[rnd.Next(0, users.Count)];
    }
    

    #endregion
    

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

    #region USECASE GETROUND
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

    #endregion

    #region Comprobadores

    
    public bool IsFinished() // HA FINALIZADO MATCH?
    {
        if (!match.rounds.Any(x => x == null) && match.rounds.All(x => x.roundFinished))
        {
            return true;
        }

        return false;
    }

    public bool ChallengerWon() // CORROBORAR GANADOR
    {
        int wonRoundsCount = 0;

        for(int i = 0; i < match.rounds.Length; i++)
        {
            if(match.rounds[i].challengerResult.Where(x => x == true).Count() > match.rounds[i].opponentResult.Where(x => x == true).Count())
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

    public bool CheckActiveMatch() //Verificar Match Activo
    {
        return (_matchService.GetActiveMatch() != null);
    }

    public bool IsChallengerTurn() //Verificar turno
    {
        return (CheckActiveMatch() && GetCurrentRound().opponentAnswers == null);
    }

    #endregion
    
    #region USECASE TIMEACTION
    public void SaveTimeToRound(int timeLeft)
    {
        Round round = GetCurrentRound();
        round.timer = 60 - timeLeft;
        UnityEngine.Debug.Log((timeLeft));
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

    #endregion
}

