using Assets.Scripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Presenters
{
    public class OngoingMatchPresenter
    {
        public void SaveCurrentMatch(int matchId)
        {
            SetActiveMatch action = new SetActiveMatch();
            action.Execute(matchId);
        }
    }
}
