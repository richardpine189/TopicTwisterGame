using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using System;
using NSubstitute.Core.Events;
using UnityEngine.SceneManagement;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;


//PASAR A PLAYMODE
public class NewGamePresenterShould
{
   
    [Test]
    public void ChangeSceneWhenButtonClicked()
    {
        INewGameView view = Substitute.For<INewGameView>();
        NewGamePresenter newGamePresenter = new NewGamePresenter(view);

        //Act
        view.OnNewGameButtonClick += Raise.Event<Action>();

        //Assert
    }
}