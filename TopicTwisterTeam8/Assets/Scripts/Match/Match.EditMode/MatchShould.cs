using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Team8.TopicTwister.Assets.Scripts;

public class MatchShould
{
    Match _match;

    [SetUp]
    public void SetUp()
    {
        _match = new Match();
    }

    [Test]
    public void GivenAMatch_CreateNewRound()
    {
        var round = _match.CreateRound();

        Assert.IsNotNull(round);
    }

    //[Test]
    //public void GivenAMatch_GetMatchState()
    //{
    //    //0 = no termino la partida

    //    Match match = new Match();

    //    Assert.AreEqual(0, match.GetState());
    //}
}

public class Match
{
    private User opponent;

    public Match(User opponent)
    {
        this.opponent = opponent;
    }

    public object CreateRound()
    {
        return new object();
    }
}