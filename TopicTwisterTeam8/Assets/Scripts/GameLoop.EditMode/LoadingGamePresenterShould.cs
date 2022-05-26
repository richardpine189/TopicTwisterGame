using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Team8.TopicTwister.Assets.Scripts;
using UnityEngine;
using UnityEngine.TestTools;

public class LoadingGamePresenterShould
{
    private LoadingGamePresenter _gamePresenter;
    private IGameLoopView _view;
    private Match _match;

    [Test]
    public void ShowPlayersInfoWhenAMatchIsCreated()
    {
        // Arrange
        string playerName = "Test Jugador";
        string opponentName = "Test Oponente";
        User user = new User(1, playerName);
        User opponent = new User(2, opponentName);

        _view = Substitute.For<IGameLoopView>();
        _match = new Match(user, opponent);

        // Act
        WhenAPresenterIsCreated();

        // Assert
        ThenShowPlayersInfo(playerName, opponentName);
    }

    private void WhenAPresenterIsCreated()
    {
        _gamePresenter = new LoadingGamePresenter(_view, _match);
    }

    private void ThenShowPlayersInfo(string playerName, string opponentName)
    {
        _view.Received().ShowPlayersInfo(playerName, opponentName);
    }
}

/*

    NO ESTAMOS USANDO NINGÚN TIPO DE USE CASES, EL PRESENTER PASA DIRECTO AL MODELO, ¿BIEN? ¿MAL?

 */

internal class LoadingGamePresenter
{
    private IGameLoopView _view;
    private Match _match;

    public LoadingGamePresenter(IGameLoopView view, Match match)
    {
        _view = view;
        _match = match;

        _view.ShowPlayersInfo(_match.Player.UserName, _match.Opponent.UserName);
    }
}

public class Match
{
    User _user;
    User _opponent;

    public User Player
    {
        get
        {
            return _user;
        }
    }

    public User Opponent
    {
        get
        {
            return _opponent;
        }
    }

    public Match(User user, User opponent)
    {
        _user = user;
        _opponent = opponent;
    }
}

public interface IGameLoopView
{
    void ShowPlayersInfo(string playerName, string opponentName);
}