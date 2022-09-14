namespace Core.Match.PlayersNames
{
    public class PlayerNamePresenter
    {
        private readonly IGetMatchOpponentUseCase _getMatchOpponent;
        private readonly IGetMatchChallengerUseCase _getMatchChallenger;
        private readonly IPlayerNameView _playerNameView;
        private readonly ILoadingGameView _loadingGameView;

        public PlayerNamePresenter(IPlayerNameView playerNameView,IGetMatchOpponentUseCase getMatchOpponent,IGetMatchChallengerUseCase getMatchChallenger, ILoadingGameView loadingGameView)
        {
            _playerNameView = playerNameView;
            _getMatchChallenger = getMatchChallenger;
            _getMatchOpponent = getMatchOpponent;
            _loadingGameView = loadingGameView;
            
            _loadingGameView.OnSendNamesInHeader += InitializeNameInHeader;
        }

        ~PlayerNamePresenter()
        {
            
            _loadingGameView.OnSendNamesInHeader -= InitializeNameInHeader;
        }
        
        private void InitializeNameInHeader()
        {
            var opponentName = _getMatchOpponent.Execute();
            var challengerName = _getMatchChallenger.Execute();
            _playerNameView.SetInUIPlayerName(challengerName, opponentName);
        }
        
    }
}