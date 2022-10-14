namespace Core.Match.PlayersNames
{
    public class PlayerNamePresenter
    {
        private readonly IGetMatchDataUseCase _getMatchDataUseCase;
        private readonly IPlayerNameView _playerNameView;
        private readonly ILoadingGameView _loadingGameView;
        private readonly ILocalPlayerDataRepository _localPlayerData;

        public PlayerNamePresenter(IPlayerNameView playerNameView,IGetMatchDataUseCase getMatchDataUseCase, ILoadingGameView loadingGameView, ILocalPlayerDataRepository localPlayerData)
        {
            _localPlayerData = localPlayerData;
            _playerNameView = playerNameView;
            _getMatchDataUseCase = getMatchDataUseCase;
            _loadingGameView = loadingGameView;
            _loadingGameView.OnSendNamesInHeader += InitializeNameInHeader;
        }

        ~PlayerNamePresenter()
        {
            
            _loadingGameView.OnSendNamesInHeader -= InitializeNameInHeader;
        }
        
        private void InitializeNameInHeader()
        {
            var playerLogged = _localPlayerData.GetData().name;
            var challengerName = _getMatchDataUseCase.GetChallengerName();
            var opponentName = _getMatchDataUseCase.GetOpponentName();

            if(playerLogged == challengerName)
            {
                _playerNameView.SetInUIPlayerName(challengerName, opponentName);
            }
            else
            {
                _playerNameView.SetInUIPlayerName(opponentName, challengerName);
            }
        }
        
    }
}