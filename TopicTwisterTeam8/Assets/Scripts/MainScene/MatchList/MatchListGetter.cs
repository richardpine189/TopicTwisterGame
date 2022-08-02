using System.Collections.Generic;
using System.Linq;
using Zenject;

public class MatchListGetter : IGetMatchesInfo
{
    [Inject] IMatchRepository _matchRepository;
    
    public MatchViewModel[] Execute()
    {
        List<Match> matches = _matchRepository.GetMatchesByName(LoggedUserDTO.PlayerName);

        IsMatchFinishedAction isMatchFinished = new IsMatchFinishedAction();

        if (matches != null)
        {
            return matches.Select(m => new MatchViewModel
            {
                idMatch = (int)m.id,
                challengerName = m.challenger.UserName,
                opponentName = m.opponent.UserName,
                currentRound = m.rounds.All(x => x == null) ? 1 : m.rounds.Where(t => t != null).Count(),
                isChallengerTurn = m.isChallengerTurn,
                isMatchFinished = isMatchFinished.Execute(m)
            }).ToArray();
        }
        else
        {
            return new MatchViewModel[0];
        }
    }
}