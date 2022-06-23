using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Tests
{
    public class LoadingGamePresenterShould
    {
        private LoadingGamePresenter _gamePresenter;
        private ILoadingGameView _view;
        private IMatchAction _matchActions;

        [Test]
        public void ShowPlayersInfoWhenAMatchIsCreated()
        {
            // Arrange
            string playerName = "Test Jugador";
            string opponentName = "Test Oponente";

            _view = Substitute.For<ILoadingGameView>();
            _matchActions = Substitute.For<IMatchAction>();
            _matchActions.GetPlayerName().Returns(playerName);
            _matchActions.GetOpponentName().Returns(opponentName);

            // Act
            WhenAPresenterIsCreated();

            // Assert
            ThenShowPlayersInfo(playerName, opponentName);
        }

        private void WhenAPresenterIsCreated()
        {
            _gamePresenter = new LoadingGamePresenter(_view, _matchActions);
        }

        private void ThenShowPlayersInfo(string playerName, string opponentName)
        {
            _view.Received().ShowPlayersInfo(playerName, opponentName);
        }
    }
}
