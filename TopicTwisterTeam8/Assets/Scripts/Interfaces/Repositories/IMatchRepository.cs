using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IMatchRepository
    {
        void SaveMatch(Match match);

        List<Match> GetMatches();

        List<Match> GetMatchesByName(string userName);

        int GetNewId();
    }

