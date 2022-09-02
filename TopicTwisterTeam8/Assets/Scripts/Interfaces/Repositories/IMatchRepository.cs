using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMatchRepository
{
    Task SaveMatch(MatchToDeleteRefacto matchToDeleteRefacto);

    Task<List<MatchToDeleteRefacto>> GetMatches();

    Task<List<MatchToDeleteRefacto>> GetMatchesByName(string userName);

    Task<int> GetNewId();
}