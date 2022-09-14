using System;

namespace Core.Match
{
    public interface IMatchHeaderView
    {
        public void SetInUIPlayerRoundResult(bool isChallenger, RoundResult[] playerRoundStatus);
        public void SetInUIRoundNumber(string text);
    }
}