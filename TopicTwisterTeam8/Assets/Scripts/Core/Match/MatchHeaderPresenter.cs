namespace Core.Match
{
    public class MatchHeaderPresenter
    {
        private IMatchHeaderView _headerView;
        private ILoadingGameView _loadingGameView;
        private ILetterView _letterView;
        private IGetMatchOpponentUseCase _getMatchOpponent;
        private IGetMatchChallengerUseCase _getMatchChallenger;
        private IGetMatchRoundNumber _getRoundNumber;
        private IGetMatchLetterUseCase _getMatchLetter;

        private string _challengerName;
        private string _opponentName;

        private const int OFFSET_ROUND_NUMBER = 1;
        
        //Deberian ser 3 presenters...
        public MatchHeaderPresenter(IMatchHeaderView matchHeaderView,ILetterView letterView, ILoadingGameView loadingGameView, IGetMatchOpponentUseCase getMatchOpponentName, IGetMatchChallengerUseCase getMatchChallenger, IGetMatchRoundNumber getRoundNumber, IGetMatchLetterUseCase getMatchLetter)
        {
            _headerView = matchHeaderView;
            _loadingGameView = loadingGameView;
            _getMatchChallenger = getMatchChallenger;
            _getMatchOpponent = getMatchOpponentName;
            _letterView = letterView;
            _getMatchLetter = getMatchLetter;
            _getRoundNumber = getRoundNumber;
            //Status round.(OJO)
            
            
            
            _loadingGameView.OnSendNamesInHeader += InitializeHeader; //Round Number y RoundStatus
            //Subscription del letter presenter -> letter
            _letterView.UpdateLetter += SetInUIRoundLetter;
            _letterView.OnActiveLetterPanel += HideLetter;
        }

        ~MatchHeaderPresenter()
        {
            _loadingGameView.OnSendNamesInHeader -= InitializeHeader;
            _letterView.UpdateLetter -= SetInUIRoundLetter;
            _letterView.OnActiveLetterPanel -= HideLetter;
        }

        private void InitializeHeader()
        {
            _opponentName = _getMatchOpponent.Execute();
            _challengerName = _getMatchChallenger.Execute();
            _headerView.SetInUIPlayerName(_challengerName, _opponentName);
            //Inicializar numero de ronda
            int roundNumber = _getRoundNumber.Execute();
            
            _headerView.SetInUIRoundNumber((roundNumber + OFFSET_ROUND_NUMBER).ToString());
            //Inicializar round status
        }

        private void SetInUIRoundLetter()
        {
            char? letter = _getMatchLetter.Execute();
            _headerView.SetRoundLetter(letter.ToString());
        }

        private void HideLetter()
        {
            _headerView.HideLetter();
        }
    }
}