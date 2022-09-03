using System;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class RoundTimerPresenter : IInitializable, IDisposable
    {
        IRoundTimerUseCase _roundActions;

        IRoundTimerView _view;

        public RoundTimerPresenter(IRoundTimerView view, IRoundTimerUseCase roundActions)
        {
            _view = view;
            _roundActions = roundActions;
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

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~RoundTimerPresenter() { _view.OnTimerStop -= SendTimeToRound; }
    }
}
