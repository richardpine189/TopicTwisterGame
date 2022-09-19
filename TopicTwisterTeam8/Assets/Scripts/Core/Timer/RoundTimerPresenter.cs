using System;
using Zenject;

namespace Assets.Scripts.Presenters
{
    public class RoundTimerPresenter
    {
        IRoundTimerUseCase _roundActions;

        IRoundTimerView _view;

        private IAnsweringView _answeringView;

        public RoundTimerPresenter(IRoundTimerView view, IRoundTimerUseCase roundActions, IAnsweringView answeringView)
        {
            _view = view;
            _answeringView = answeringView;
            _roundActions = roundActions;
            _view.OnTimerStart += SetInitialTime;
            _view.OnTimerStop += SendTimeToRound;
            _view.OnTimerIsUp += StopRound;
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

        private void StopRound()
        {
            _answeringView.SendAnswers();
        }
    }
}
