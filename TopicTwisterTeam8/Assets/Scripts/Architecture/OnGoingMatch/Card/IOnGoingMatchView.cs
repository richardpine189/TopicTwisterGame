using System;
using System.Drawing;

namespace Architecture.OnGoingMatch.Card
{
    public interface IOngoingMatchView
    {
        public event Action OnStartMatch;

        public void ShowWaitingClock();

        public void ShowPlayButton();

        public void SetOpponentName(string name);

        public void SetRoundNumber(int round);

        void LoadMatch();

        void SetRoundCount(string formatingScore);

        void SetCardColor(Color color);

        public void ShowFinishedMatchText();
    }
}
