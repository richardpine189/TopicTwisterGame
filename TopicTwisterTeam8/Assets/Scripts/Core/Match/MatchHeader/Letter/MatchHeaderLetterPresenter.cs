namespace Core.Match
{
    public class MatchHeaderLetterPresenter
    {
        private readonly ILetterView _letterView;
        private readonly IMatchHeaderLetterView _matchHeaderLetterView;
        private readonly IGetRoundData _getRoundData;

        public MatchHeaderLetterPresenter(ILetterView letterView, IMatchHeaderLetterView matchHeaderLetterView, IGetRoundData getRoundData)
        {
            _letterView = letterView;
            _matchHeaderLetterView = matchHeaderLetterView;
            _getRoundData = getRoundData;
            
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
            char? letter = _getRoundData.GetCurrentLetter();
            _matchHeaderLetterView.SetRoundLetter(letter.ToString());
        }
        
        private void HideLetter()
        {
            _matchHeaderLetterView.HideLetter();
        }
        
                
    }
}