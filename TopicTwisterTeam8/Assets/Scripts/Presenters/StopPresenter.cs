using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class StopPresenter
    {
        private IAnsweringView _view;
        private IAnswerSender _answerSender;

        public StopPresenter(IAnsweringView view, IAnswerSender answerSender)
        {
            _view = view;
            _answerSender = answerSender;
            _view.OnStopClick += SendAnswersAction;
        }

        private void SendAnswersAction(string[] answers)
        {
            _answerSender.SendAnswers(answers);
        }
    }
}
