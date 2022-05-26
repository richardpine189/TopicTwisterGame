using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StopPresenterShould
{
    
    [Test]
    public void SendAnswers_WhenStopButtonClicked()
    {
        // Arrange
        string[] answers = { "hola", "chau", "test", "", " " };
        IAnsweringView _view = Substitute.For<IAnsweringView>();
        StopPresenter _presenter = new StopPresenter(_view);

        // Act
        _view.OnStopClick += Raise.Event<Action<string[]>>(answers);

        // Assert
        _presenter.Received().SendAnswersAction(answers);
    }
}

internal class StopPresenter
{
    private IAnsweringView _view;
    private StopAction _stopAction;

    public StopPresenter(IAnsweringView view)
    {
        _view = view;
         _stopAction = new StopAction();
        _view.OnStopClick += SendAnswersAction;
    }

    private void SendAnswersAction(string[] answers)
    {
        _stopAction.SendAnswers(answers);
    }
}

internal interface IAnsweringView
{
    event Action<string[]> OnStopClick;
}

public class StopAction
{
    public void SendAnswers(string[] answers)
    {
        
    }
}