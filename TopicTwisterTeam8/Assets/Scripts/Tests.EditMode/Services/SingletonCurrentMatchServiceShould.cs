using Assets.Scripts.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Tests.EditMode.Services
{
    class SingletonCurrentMatchServiceShould
    {
        [Test]
        public void GivenMatch_SaveMatch()
        {
            // Arrange
            User challenger = new User(1, "test");
            User opponent = new User(44, "test2");
            Match match = new Match();
            match.challenger = challenger;
            match.opponent = opponent;
            Match expectedMatch = match;
            SingletonCurrentMatchService _matchService = new SingletonCurrentMatchService();

            // Act
            _matchService.SetActiveMatch(expectedMatch);

            // Assert
            Assert.AreEqual(expectedMatch, _matchService.GetActiveMatch());
        }
    }
}
