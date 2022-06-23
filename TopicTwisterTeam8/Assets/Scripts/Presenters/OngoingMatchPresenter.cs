using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class OngoingMatchPresenter
    {
        public void SaveCurrentMatch(int matchId)
        {
            SetActiveMatch action = new SetActiveMatch();
            action.Execute(matchId);
        }
    }

