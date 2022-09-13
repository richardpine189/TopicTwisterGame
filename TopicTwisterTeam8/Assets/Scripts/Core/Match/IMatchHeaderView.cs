using System;

namespace Core.Match
{
    public interface IMatchHeaderView
    {
        public void SetPanelTitleText(string text);
        public void SetInUIPlayerName(string challenger, string opponent);
        public void SetInUIPlayerRoundResult(bool isChallenger, RoundResult[] playerRoundStatus);
        public void SetInUIRoundNumber(string text);
        public void SetRoundLetter(string letter);

    }
}