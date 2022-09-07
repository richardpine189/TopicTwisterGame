using UnityEngine;

namespace MainScene.MatchList.Repository
{
    public class PlayerPrefMatchIdRepository : IMatchIdRepository
    {
        public void SaveMatchId(int matchId)
        {
            PlayerPrefs.SetInt("MatchId", matchId);
        }

        public int GetMatchId()
        {
            return PlayerPrefs.GetInt("MatchId");
        }
    }
}