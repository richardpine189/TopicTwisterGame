namespace Core.Match
{
    public class MatchHeaderPresenter
    {
        private readonly IMatchHeaderView _headerView;
        private readonly ILoadingGameView _loadingGameView;
        private readonly IGetMatchData _getMatchData;
        private readonly IEndRoundView _endRoundView;

        private string _challengerName;
        private string _opponentName;

        private const int OFFSET_ROUND_NUMBER = 1;

        public MatchHeaderPresenter(IMatchHeaderView matchHeaderView, ILoadingGameView loadingGameView, IGetMatchData getMatchData, IEndRoundView endRoundView)
        {
            _headerView = matchHeaderView;
            _loadingGameView = loadingGameView;
            _getMatchData = getMatchData;
            _endRoundView = endRoundView;
            _loadingGameView.OnSendNamesInHeader += InitializeHeader;
            _loadingGameView.SincronizeRoundNumber += SubtractRoundNumber;
            _endRoundView.OnSetRoundNumber += UpdateRoundNumber;
        }

        ~MatchHeaderPresenter()
        {
            _loadingGameView.OnSendNamesInHeader -= InitializeHeader;
            _endRoundView.OnSetRoundNumber -= UpdateRoundNumber;
            _loadingGameView.SincronizeRoundNumber -= SubtractRoundNumber;
        }

        private void InitializeHeader()
        {
            int roundNumber = _getMatchData.GetRoundNumber();
            
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
            
            //TODO: Inicializar round status
        }

        private void UpdateRoundNumber()
        {
            int roundNumber = _getMatchData.GetRoundNumber();
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
        }
        
        private void SubtractRoundNumber()
        {
            int roundNumber = _getMatchData.GetRoundNumber();
            _headerView.SetInUIRoundNumber((roundNumber).ToString());
        }
    }
}