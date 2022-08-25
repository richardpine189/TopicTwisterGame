using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface ILoadingGameView
    {
        void SetPlayersInfoInView(string playerName, string opponentName);
        public void ShowEndRoundSection();
        public void ShowCategoriesSection();

        public void StartAnimation(bool isNewGame);
        public event Action OnReadyForNext;
}

