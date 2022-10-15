using Architecture.Match.Panel.LoadingMatch;
using Architecture.Match.UseCases.GetMatchData;

namespace Architecture.Match.MatchHeader.RoundStatus
{
    public class MatchHeaderPresenter
    {
        private IMatchHeaderView _headerView;
        private ILoadingGameView _loadingGameView;
        private IGetMatchDataUseCase _getMatchDataUseCase;

        private string _challengerName;
        private string _opponentName;

        private const int OFFSET_ROUND_NUMBER = 1;

        public MatchHeaderPresenter(IMatchHeaderView matchHeaderView, ILoadingGameView loadingGameView, IGetMatchDataUseCase getMatchDataUseCase)
        {
            _headerView = matchHeaderView;
            _loadingGameView = loadingGameView;
            _getMatchDataUseCase = getMatchDataUseCase;
            _loadingGameView.OnSendNamesInHeader += InitializeHeader;
        }

        ~MatchHeaderPresenter()
        {
            _loadingGameView.OnSendNamesInHeader -= InitializeHeader;

        }

        private void InitializeHeader()
        {
            int roundNumber = _getMatchDataUseCase.GetRoundNumber();
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
            
            //TODO: Inicializar round status
        }
    }
}