using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using Team8.TopicTwister.Assets.Scripts;

public class MatchShould
{
    User _opponent;
    Match _match;

    [SetUp]
    public void SetUp()
    {
        _opponent = new User(2, "test");
        _match = new Match(_opponent);
    }

    [Test]
    public void GivenAMatch_CreateNewRound()
    {
        var round = _match.CreateRound();

        Assert.IsNotNull(round);
    }

    //[Test]
    //public void GivenAnOngoingMatch_GetMatchState()
    //{
    //    //0 = no termino la partida

    //    Assert.AreEqual(0, _match.GetState());
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