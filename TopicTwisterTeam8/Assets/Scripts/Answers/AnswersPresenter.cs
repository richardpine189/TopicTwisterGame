using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnswersPresenter : IInitializable, IDisposable
{
    private IAnsweringView _view;

    private IAssignAnswersUseCase _assignAnswers;

    public AnswersPresenter(IAnsweringView view, IAssignAnswersUseCase assignAnswers)
    {
        _view = view;
        _assignAnswers = assignAnswers;
    }

    private void SendAnswersAction(string[] answers)
    {
        _assignAnswers.Execute(answers);
    }

    public void Initialize()
    {
        _view.OnStopClick += SendAnswersAction;
    }

    public void Dispose()
    {
        //throw new NotImplementedException();
    }
}
