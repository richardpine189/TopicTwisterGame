using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Repositories
{
    public class JsonMatchRepository : IMatchRepository
    {
        public List<Match> GetMatches()
        {
            return SaveDataToJson.LoadFromJson<List<Match>>("testMatch");
        }

        public void SaveMatch(Match match)
        {
            List<Match> matches = SaveDataToJson.LoadFromJson<List<Match>>("testMatch");

            if(matches == null)
            {
                matches = new List<Match>();
            }

            int matchIndex = GetMatchIndexById(match.id.Value);

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

        public int GetMatchIndexById(int id)
        {
            List<Match> matches = GetMatches();

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

        public int GetNewId()
        {
            int highestId = -1;
            List<Match> matches = GetMatches();

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
    }
}
