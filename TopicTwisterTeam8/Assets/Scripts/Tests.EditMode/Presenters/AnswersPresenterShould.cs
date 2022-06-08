using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AnswersPresenterShould
{
    [Test]
    public void SendAnswers_WhenStopButtonClicked()
    {
        // Arrange
        string[] answers = { "hola", "chau", "test" };


        IAnsweringView _view = Substitute.For<IAnsweringView>();
        IAnswerSender _answerSender = Substitute.For<IAnswerSender>();
        AnswersPresenter _presenter = new AnswersPresenter(_view, _answerSender);

        // Act
        _view.OnStopClick += Raise.Event<Action<string[]>>(answers);


        // Assert
        _answerSender.Received().SendAnswers(answers);
    }
}
