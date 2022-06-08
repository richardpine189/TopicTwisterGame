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
            Match expectedMatch = new Match(new User(1, "test"), new User(44, "test2"));
            SingletonCurrentMatchService _matchService = new SingletonCurrentMatchService();

            // Act
            _matchService.Save(expectedMatch);

            // Assert
            Assert.AreEqual(expectedMatch, _matchService.Get());
        }
    }
}
