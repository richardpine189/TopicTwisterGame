namespace Core.Match
{
    public class MatchHeaderLetterPresenter
    {
        private readonly ILetterView _letterView;
        private readonly IMatchHeaderLetterView _matchHeaderLetterView;
        private readonly IGetRoundDataUseCase _getRoundDataUseCase;

        public MatchHeaderLetterPresenter(ILetterView letterView, IMatchHeaderLetterView matchHeaderLetterView, IGetRoundDataUseCase getRoundDataUseCase)
        {
            _letterView = letterView;
            _matchHeaderLetterView = matchHeaderLetterView;
            _getRoundDataUseCase = getRoundDataUseCase;
            
            _letterView.UpdateLetter += SetInUIRoundLetter;
            _letterView.OnActiveLetterPanel += HideLetter;
        }

        ~MatchHeaderLetterPresenter()
        {
            _letterView.UpdateLetter -= SetInUIRoundLetter;
            _letterView.OnActiveLetterPanel -= HideLetter;
        }

        private void SetInUIRoundLetter()
        {
            char? letter = _getRoundDataUseCase.GetCurrentLetter();
            _matchHeaderLetterView.SetRoundLetter(letter.ToString());
        }
        
        private void HideLetter()
        {
            _matchHeaderLetterView.HideLetter();
        }
        
                
    }
}