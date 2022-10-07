namespace Core.Match.PlayersNames
{
    public class PlayerNamePresenter
    {
        private readonly IGetMatchData _getMatchData;
        private readonly IPlayerNameView _playerNameView;
        private readonly ILoadingGameView _loadingGameView;

        public PlayerNamePresenter(IPlayerNameView playerNameView,IGetMatchData getMatchData, ILoadingGameView loadingGameView)
        {
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
            var challengerName = _getMatchData.GetChallengerName();
            var opponentName = _getMatchData.GetOpponentName();

            if(UserDTO.PlayerName == challengerName)
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