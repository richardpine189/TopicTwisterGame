using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            MatchToDeleteRefacto matchToDeleteRefacto = new MatchToDeleteRefacto();
            matchToDeleteRefacto.challenger = challenger;
            matchToDeleteRefacto.opponent = opponent;
            MatchToDeleteRefacto expectedMatchToDeleteRefacto = matchToDeleteRefacto;
            SingletonCurrentMatchService _matchService = new SingletonCurrentMatchService();

            // Act
            _matchService.SetActiveMatch(expectedMatchToDeleteRefacto);

            // Assert
            Assert.AreEqual(expectedMatchToDeleteRefacto, _matchService.GetActiveMatch());
        }
    }
}
