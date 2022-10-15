using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//public class AnswersPresenterShould
//{
//    [Test]
//    public void SendAnswers_WhenStopButtonClicked()
//    {
//        // Arrange
//        string[] answers = { "hola", "chau", "test" };


//        IAnsweringView _view = Substitute.For<IAnsweringView>();
//        IAnswersRepository _answerRepository = Substitute.For<IAnswersRepository>();
//        AnswersPresenter _presenter = new AnswersPresenter(_view);

//        // Act
//        _view.OnStopClick += Raise.Event<Action<string[]>>(answers);


//        // Assert
//        _answerRepository.Received().SaveAnswers(answers);
//    }
//}
