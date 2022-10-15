using System;

namespace Architecture.Match.Panel.LoadingMatch
{
    public interface ILoadingGameView
    {
        void SetChallenger(string challengerName);
        void SetOpponent(string opponentName);
        public void ShowEndRoundSection();
        public void ShowCategoriesSection();

        public void StartAnimation(bool isNewGame);
        public event Action OnReadyForNext;
        public event Action OnSendNamesInHeader;
    }
}

