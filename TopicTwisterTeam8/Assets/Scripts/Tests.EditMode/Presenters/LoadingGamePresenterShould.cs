using Assets.Scripts.Presenters;
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
        private IActiveMatch _matchActions;

        [Test]
        public void ShowPlayersInfoWhenAMatchIsCreated()
        {
            // Arrange
            string playerName = "Test Jugador";
            string opponentName = "Test Oponente";

            _view = Substitute.For<ILoadingGameView>();
            _matchActions = Substitute.For<IActiveMatch>();
            //_matchActions.GetPlayerName().Returns(playerName); BROKEN AFERT MIGRATION
            //_matchActions.GetOpponentName().Returns(opponentName);

            // Act
            WhenAPresenterIsCreated();

            // Assert
            ThenShowPlayersInfo(playerName, opponentName);
        }

        private void WhenAPresenterIsCreated()
        {
            _gamePresenter = new LoadingGamePresenter();
        }

        private void ThenShowPlayersInfo(string playerName, string opponentName)
        {
            _view.Received().SetPlayersInfoInView(playerName, opponentName);
        }
    }
}
