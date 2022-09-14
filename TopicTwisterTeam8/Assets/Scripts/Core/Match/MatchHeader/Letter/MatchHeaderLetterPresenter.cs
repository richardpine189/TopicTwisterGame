namespace Core.Match
{
    public class MatchHeaderLetterPresenter
    {
        private readonly ILetterView _letterView;
        private readonly IMatchHeaderLetterView _matchHeaderLetterView;
        private readonly IGetMatchLetterUseCase _getMatchLetter;

        public MatchHeaderLetterPresenter(ILetterView letterView, IMatchHeaderLetterView matchHeaderLetterView, IGetMatchLetterUseCase getMatchLetter)
        {
            _letterView = letterView;
            _matchHeaderLetterView = matchHeaderLetterView;
            _getMatchLetter = getMatchLetter;
            
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
            char? letter = _getMatchLetter.Execute();
            _matchHeaderLetterView.SetRoundLetter(letter.ToString());
        }
        
        private void HideLetter()
        {
            _matchHeaderLetterView.HideLetter();
        }
        
                
    }
}