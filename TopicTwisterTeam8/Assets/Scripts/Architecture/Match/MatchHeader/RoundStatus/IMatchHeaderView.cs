namespace Architecture.Match.MatchHeader.RoundStatus
{
    public interface IMatchHeaderView
    {
        public void SetInUIPlayerRoundResult(bool isChallenger, RoundResult[] playerRoundStatus);
        public void SetInUIRoundNumber(string text);
    }
}