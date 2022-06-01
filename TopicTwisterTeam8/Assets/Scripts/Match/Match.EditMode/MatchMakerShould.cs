using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Team8.TopicTwister.Assets.Scripts;
using System;

public class MatchMakerShould
{
    //Match debe comprobar que una ronda se ha iniciado correctamente. (instanciar Round)

    //comprobar 3?

    //Match debe evaluar estado de las rondas. ???

    //Match debe Finalizar una partida y comunicarle resultado a MatchService (???)

    //Match debe calificar una partida. (???)

    User _opponent;
    Match _match;

    [SetUp]
    public void SetUp()
    {
        _opponent = new User(2, "test");
        _match = new Match(_opponent);
    }

    [Test]
    public void CreateNewRound()
    {
        Round round = _match.CreateRound();

        Assert.IsNotNull(round);
    }

    [Test]
    public void GivenAnOngoingMatch_GetRoundsState()
    {
        int indexRoundToCheck = 2;
        var state = _match.GetRound(indexRoundToCheck).GetState();

        Assert.AreEqual(Round.RoundState.NotStarted, state);
    }
}

public class Round
{
    public enum RoundState {NotStarted,InGame,Awaiting,Finished}
    private RoundState _state;

    private RoundState State { get => _state; set => _state = value; }

    internal RoundState GetState()
    {
        _state = RoundState.NotStarted;
        return _state;
    }
}

public class Match
{
    private User opponent;
    private Round[] _rounds= new Round[3];

    public Match(User opponent)
    {
        this.opponent = opponent;
        for(int i=0; i <= _rounds.Length -1; i++)
            _rounds[0] = CreateRound();
    }

    public Round CreateRound()
    {
        return new Round();
    }

    internal Round GetRound(int index)
    {
        return _rounds[index];
    }
}