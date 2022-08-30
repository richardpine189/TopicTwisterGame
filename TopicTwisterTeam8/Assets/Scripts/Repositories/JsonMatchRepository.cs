using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class JsonMatchRepository : IMatchRepository, IGetMatches
{
    public async Task<List<Match>> GetMatches()
    {
        return SaveDataToJson.LoadFromJson<List<Match>>("testMatch");
    }

    public async Task<List<MatchDTO>> GetMatchesDTOByName(string userName)
    {
        List<Match> matches = await GetMatchesByName(userName);

        return MatchesToMatchDTO(matches);
    }

    public async Task<List<Match>> GetMatchesByName(string userName)
    {
        List<Match> matches = await GetMatches();

        return matches.Where(x => x.challenger.UserName == userName || x.opponent.UserName == userName).ToList();
    }

    public async Task SaveMatch(Match match)
    {
        List<Match> matches = SaveDataToJson.LoadFromJson<List<Match>>("testMatch");

        if(matches == null)
        {
            matches = new List<Match>();
        }

        int matchIndex = await GetMatchIndexById(match.id.Value);

        if (matchIndex == -1)
        {
            matches.Add(match);
        }
        else
        {
            matches[matchIndex] = match;
        }

        SaveDataToJson.SaveIntoJson<List<Match>>(matches, ref matches, "testMatch");
    }

    public async Task<int> GetMatchIndexById(int id)
    {
        List<Match> matches = await GetMatches();

        if (matches != null)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (matches[i].id == id)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public async Task<int> GetNewId()
    {
        int highestId = -1;
        List<Match> matches = await GetMatches();

        if (matches != null)
        {
            for (int i = 0; i < matches.Count; i++)
            {
                if (highestId < matches[i].id)
                {
                    highestId = (int)matches[i].id;
                }
            }
        }

        return highestId + 1;
    }

    private List<MatchDTO> MatchesToMatchDTO(List<Match> matches)
    {
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
            }).ToList();
        }
        else
        {
            return new List<MatchDTO>();
        }
    }
}
