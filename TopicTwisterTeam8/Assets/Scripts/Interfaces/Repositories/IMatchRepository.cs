using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Interfaces
{
    public interface IMatchRepository
    {
        void SaveMatch(Match match);

        List<Match> GetMatches();

        int GetNewId();
    }
}
