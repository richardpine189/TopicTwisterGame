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
        HardcodedRoundActions _roundActions;

        public RoundTimerPresenter(RoundTimerView view)
        {
            _view = view;
            _roundActions = new HardcodedRoundActions();
            SetInitialTime();
            _view.OnTimerStop += SendTimeToRound;
        }

        private void SetInitialTime()
        {
            int timeToAnswer = _roundActions.GetTimeToAnswer();
            _view.SetTimeLeft(timeToAnswer);
        }

        private void SendTimeToRound(int timeLeft)
        {
            _roundActions.SaveTimeToRound(timeLeft);
        }

        ~RoundTimerPresenter() { _view.OnTimerStop -= SendTimeToRound; }
    }
}
