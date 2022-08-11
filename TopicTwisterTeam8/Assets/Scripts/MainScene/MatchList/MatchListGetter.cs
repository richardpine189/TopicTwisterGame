using System.Collections.Generic;
using System.Linq;
using Zenject;

public class MatchListGetter : IGetMatchesInfo
{
    IMatchRepository _matchRepository;

    ILocalPlayerDataRepository _localPlayerDataRepository;

    public MatchListGetter(IMatchRepository matchRepository, ILocalPlayerDataRepository localPlayerDataRepository)
    {
        _matchRepository = matchRepository;
        _localPlayerDataRepository = localPlayerDataRepository;
    }
    
    public MatchDTO[] Execute()
    {
        //List<Match> matches = _matchRepository.GetMatchesByName(UserDTO.PlayerName);
        List<Match> matches = _matchRepository.GetMatchesByName(_localPlayerDataRepository.GetData().name);

        IsMatchFinishedAction isMatchFinished = new IsMatchFinishedAction();

        if (matches != null)
        {
            return matches.Select(m => new MatchDTO
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
            return new MatchDTO[0];
        }
    }
}