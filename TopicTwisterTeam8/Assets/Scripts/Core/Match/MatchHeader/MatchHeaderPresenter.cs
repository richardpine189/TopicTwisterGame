namespace Core.Match
{
    public class MatchHeaderPresenter
    {
        private IMatchHeaderView _headerView;
        private ILoadingGameView _loadingGameView;
        private IGetMatchData _getMatchData;

        private string _challengerName;
        private string _opponentName;

        private const int OFFSET_ROUND_NUMBER = 1;

        public MatchHeaderPresenter(IMatchHeaderView matchHeaderView, ILoadingGameView loadingGameView, IGetMatchData getMatchData)
        {
            _headerView = matchHeaderView;
            _loadingGameView = loadingGameView;
            _getMatchData = getMatchData;
            _loadingGameView.OnSendNamesInHeader += InitializeHeader;
        }

        ~MatchHeaderPresenter()
        {
            _loadingGameView.OnSendNamesInHeader -= InitializeHeader;

        }

        private void InitializeHeader()
        {
            int roundNumber = _getMatchData.GetRoundNumber();
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
            
            //TODO: Inicializar round status
        }
    }
}