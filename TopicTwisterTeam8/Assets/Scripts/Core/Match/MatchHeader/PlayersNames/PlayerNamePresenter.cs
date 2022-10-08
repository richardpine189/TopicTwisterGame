namespace Core.Match.PlayersNames
{
    public class PlayerNamePresenter
    {
        private readonly IGetMatchData _getMatchData;
        private readonly IPlayerNameView _playerNameView;
        private readonly ILoadingGameView _loadingGameView;
        private readonly ILocalPlayerDataRepository _localPlayerData;

        public PlayerNamePresenter(IPlayerNameView playerNameView,IGetMatchData getMatchData, ILoadingGameView loadingGameView, ILocalPlayerDataRepository localPlayerData)
        {
            _localPlayerData = localPlayerData;
            _playerNameView = playerNameView;
            _getMatchData = getMatchData;
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
            var challengerName = _getMatchData.GetChallengerName();
            var opponentName = _getMatchData.GetOpponentName();

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