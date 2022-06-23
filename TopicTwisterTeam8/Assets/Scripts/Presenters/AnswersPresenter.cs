
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class AnswersPresenter
    {
        private IAnsweringView _view;
        private IAnswersRepository _answersRepository;

        public AnswersPresenter(IAnsweringView view, IAnswersRepository answersRepository)
        {
            _view = view;
            _answersRepository = answersRepository;
            _view.OnStopClick += SendAnswersAction;
        }

        private void SendAnswersAction(string[] answers)
        {
            _answersRepository.SaveAnswers(answers);
        }
    }

