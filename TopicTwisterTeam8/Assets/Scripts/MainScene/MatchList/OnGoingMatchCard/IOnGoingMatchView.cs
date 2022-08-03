namespace MainScene.MatchList.OnGoingMatchCard
{
    public interface IOnGoingMatchView
    {
        public void ShowWaitingClock();
        public void ShowPlayButton();
        void SetFields(MatchViewModel match);
        void LoadMatch();
    }
}