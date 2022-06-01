using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Team8.TopicTwister.Assets.Scripts;
using System;
using NSubstitute.Core.Events;
using UnityEngine.SceneManagement;


//PASAR A PLAYMODE
public class NewGamePresenterShould
{
   
    [Test]
    public void ChangeSceneWhenButtonClicked()
    {
        INewGameView view = Substitute.For<INewGameView>();
        INewGameAction newGameAction = Substitute.For<INewGameAction>();
        NewGamePresenter newGamePresenter = new NewGamePresenter(view, newGameAction);

        //Act
        view.OnNewGameButtonClick += Raise.Event<Action>();

        //Assert
        newGameAction.Received(1).InitializeMatchMaker();
    }
}

public interface INewGameAction
{
    public void InitializeMatchMaker();
}

public class NewGamePresenter
{
    private INewGameView _view;
    private INewGameAction _action;

    public NewGamePresenter(INewGameView view, INewGameAction action)
    {
        _action = action;
        _view = view;
        _view.OnNewGameButtonClick += LoadGameLoopScene;
    }

    private void LoadGameLoopScene()
    {

        //ChangeSceneLogic
        
        //SceneManager.LoadScene("nameScene");
        _action.InitializeMatchMaker();
    }
}

public interface INewGamePresenter
{
    public void CreateNewMatch();
}

public interface INewGameView
{
    event Action OnNewGameButtonClick;
}