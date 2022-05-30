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
        char letter = 'A';
        ILetterView _view = Substitute.For<ILetterView>();
        ILetterGetter _letterGetter = Substitute.For<ILetterGetter>();
        _letterGetter.GetLetter().Returns(letter);
        LetterPresenter _presenter = new LetterPresenter(_view, _letterGetter);

        // Act
        _view.OnSpinClick += Raise.Event<Action>();

        // Assert
        _view.Received().ShowLetter(letter);
    }
}

public class LetterPresenter
{
    private ILetterView _view;
    private ILetterGetter _letterGetter;

    public LetterPresenter(ILetterView view, ILetterGetter letterGetter)
    {
        _view = view;
        _letterGetter = letterGetter;
        _view.OnSpinClick += GetLetter;
    }

    private void GetLetter()
    {
        char rndLetter = _letterGetter.GetLetter();

        _view.ShowLetter(rndLetter);
    }
}

public interface ILetterView
{
    void ShowLetter(char letter);

    event Action OnSpinClick;
}