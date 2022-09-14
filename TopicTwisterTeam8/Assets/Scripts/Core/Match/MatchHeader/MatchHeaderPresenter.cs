namespace Core.Match
{
    public class MatchHeaderPresenter
    {
        private IMatchHeaderView _headerView;
        private ILoadingGameView _loadingGameView;
        private IGetMatchRoundNumber _getRoundNumber;

        private string _challengerName;
        private string _opponentName;

        private const int OFFSET_ROUND_NUMBER = 1;

        public MatchHeaderPresenter(IMatchHeaderView matchHeaderView, ILoadingGameView loadingGameView, IGetMatchRoundNumber getRoundNumber)
        {
            _headerView = matchHeaderView;
            _loadingGameView = loadingGameView;
            _getRoundNumber = getRoundNumber;
            
            _loadingGameView.OnSendNamesInHeader += InitializeHeader;
           
        }

        ~MatchHeaderPresenter()
        {
            _loadingGameView.OnSendNamesInHeader -= InitializeHeader;

        }

        private void InitializeHeader()
        {
            int roundNumber = _getRoundNumber.Execute();
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
            
            //Inicializar round status
        }
    }
}