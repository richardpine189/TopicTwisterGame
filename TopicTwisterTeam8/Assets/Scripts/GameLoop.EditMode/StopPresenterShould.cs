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
        String[] answers = { "hola", "chau", "test", "", " " };
        IAnsweringView _view = Substitute.For<IAnsweringView>();
        IAnswerSender _answerSender = Substitute.For<IAnswerSender>();
        StopPresenter _presenter = new StopPresenter(_view, _answerSender);

        // Act
        _view.OnStopClick += Raise.Event<Action<string[]>>(answers);

        // Assert
        _answerSender.Received().SendAnswers(answers);
    }
}

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

    private void SendAnswersAction(String[] answers)
    {
        _answerSender.SendAnswers(answers);
    }
}

public interface IAnsweringView
{
    event Action<string[]> OnStopClick;
}

public interface IAnswerSender
{
    public void SendAnswers(string[] answers);
}