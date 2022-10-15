using Architecture.Match.UseCases.GetRoundData;

namespace Architecture.Match.MatchHeader.Letter
{
    public class MatchHeaderLetterPresenter
    {
        private readonly Architecture.Letter.View.ILetterView _letterView;
        private readonly IMatchHeaderLetterView _matchHeaderLetterView;
        private readonly IGetRoundDataUseCase _getRoundDataUseCase;

        public MatchHeaderLetterPresenter(Architecture.Letter.View.ILetterView letterView, IMatchHeaderLetterView matchHeaderLetterView, IGetRoundDataUseCase getRoundDataUseCase)
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