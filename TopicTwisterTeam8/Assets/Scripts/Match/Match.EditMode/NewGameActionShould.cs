using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;

public class NewGameActionShould
{
    
    [Test]
    public void NewGameActionShouldCreateMatchMaker()
    {
        //Arrange
        NewGameAction newGameAction = new NewGameAction();
        //Act
        newGameAction.InitializeMatchMaker();
        //Assert
        Assert.IsNotNull(newGameAction.MatchMakerPresenter);
    }

}

internal class NewGameAction : INewGameAction
{
    public IMatchMakerPresenter MatchMakerPresenter { get; private set; }

    public void InitializeMatchMaker()
    {
        MatchMakerPresenter = new MatchMakerPresenter();
    }
}

internal class MatchMakerPresenter : IMatchMakerPresenter
{
}

public interface IMatchMakerPresenter
{
}