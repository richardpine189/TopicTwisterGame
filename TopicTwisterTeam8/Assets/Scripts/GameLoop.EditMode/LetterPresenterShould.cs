using System;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LetterPresenterShould
{
    [Test]
    public void ShowRandomLetter_WhenButtonClick()
    {
        // Arrange
        ILetterView _view = Substitute.For<ILetterView>();
        LetterPresenter _presenter = new LetterPresenter(_view);

        // Act
        _view.OnSpinClick += Raise.Event<Action>();

        // Assert
        // ¿COMO TESTEAR UN MÉTODO RANDOM? ¿PRIVADO?
        _view.Received().ShowLetter('A');
    }
}

public class LetterPresenter
{
    private ILetterView _view;

    public LetterPresenter(ILetterView view)
    {
        _view = view;
        _view.OnSpinClick += GetLetter;
    }

    private void GetLetter()
    {
        // TODO

        _view.ShowLetter('A');
    }
}

public interface ILetterView
{
    void ShowLetter(char letter);

    event Action OnSpinClick;
}