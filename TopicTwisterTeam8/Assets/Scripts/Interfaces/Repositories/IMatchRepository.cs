using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMatchRepository
{
    Task SaveMatch(Match match);

    Task<List<Match>> GetMatches();

    Task<List<Match>> GetMatchesByName(string userName);

    Task<int> GetNewId();
}