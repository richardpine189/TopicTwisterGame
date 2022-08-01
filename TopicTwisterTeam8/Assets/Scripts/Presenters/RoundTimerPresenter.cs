using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Presenters
{
    public class RoundTimerPresenter
    {
        RoundTimerView _view;
        HardcodedMatchActions _matchActions;

        public RoundTimerPresenter(RoundTimerView view)
        {
            _view = view;
            _matchActions = new HardcodedMatchActions();
            SetInitialTime();
            _view.OnTimerStop += SendTimeToRound;
        }

        private void SetInitialTime()
        {
            _matchActions.GetMatch();
            int timeToAnswer = _matchActions.GetTimeToAnswer();
            _view.SetTimeLeft(timeToAnswer);
        }

        private void SendTimeToRound(int timeLeft)
        {
            _matchActions.SaveTimeToRound(timeLeft);
        }

        ~RoundTimerPresenter() { _view.OnTimerStop -= SendTimeToRound; }
    }
}
