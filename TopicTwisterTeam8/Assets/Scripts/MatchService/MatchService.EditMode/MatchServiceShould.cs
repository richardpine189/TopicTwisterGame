using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Team8.TopicTwister.Assets.Scripts;
using UnityEngine;
using UnityEngine.TestTools;

public class MatchServiceShould
{
    [Test]
    public void FindOpponent()
    {
        MatchService matchService = new MatchService();

        var user = matchService.FindOpponent();

        Assert.IsNotNull(user);
    }

    [Test]
    public void GivenOpponent_StartNewMatch()
    {
        MatchService matchService = new MatchService();

        User opponent = new User(1, "test");

        matchService.CreateMatch(opponent);
    }
}

public class MatchService
{
    public object FindOpponent()
    {
        return new object();
    }

    public bool CreateMatch(User opponent)
    {
        Match newMatch = new Match(opponent);

        return true;
    }
}