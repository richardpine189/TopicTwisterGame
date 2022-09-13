using System;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class RoundTimerPresenter
    {
        IRoundTimerUseCase _roundActions;

        IRoundTimerView _view;

        public RoundTimerPresenter(IRoundTimerView view, IRoundTimerUseCase roundActions)
        {
            _view = view;
            _roundActions = roundActions;
            _view.OnTimerStart += SetInitialTime;
            _view.OnTimerStop += SendTimeToRound;
        }

        ~RoundTimerPresenter()
        {
            _view.OnTimerStart -= SetInitialTime;
            _view.OnTimerStop -= SendTimeToRound;
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
    }
}
