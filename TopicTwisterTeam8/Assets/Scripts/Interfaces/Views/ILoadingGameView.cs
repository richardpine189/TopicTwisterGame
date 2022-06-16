using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface ILoadingGameView
    {
        void ShowPlayersInfo(string playerName, string opponentName);
        public void ShowEndRoundSection();
        public void ShowCategoriesSection();

        
    }
}
