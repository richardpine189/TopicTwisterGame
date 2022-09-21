public class LetterPresenter
{
    private ILetterView _letterView;
    private IGetLetterUseCase _getLetter;
    private IGetRoundData _getRoundData;
    private ISaveRoundData _saveRoundData;

    private char _currentLetter;
    public LetterPresenter(ILetterView letterView, IGetLetterUseCase getLetter, ISaveRoundData saveRoundData, IGetRoundData getRoundData)
    {
        _letterView = letterView;
        _getLetter = getLetter;
        _getRoundData = getRoundData;
        _saveRoundData = saveRoundData;
        _letterView.OnAskForLetter += AskForLetter;
        _letterView.OnKeepRoundLetter += KeepLetter;
    }

    ~LetterPresenter()
    {
        _letterView.OnAskForLetter -= AskForLetter;
        _letterView.OnKeepRoundLetter -= KeepLetter;
    }
    
    private void AskForLetter()
    {
        char? tempLetter = _getRoundData.GetCurrentLetter();
        if (tempLetter == null)
        {
            tempLetter = _getLetter.Execute();
        }
        UpdateInterface((char)tempLetter);
    }

    private void KeepLetter()
    {
        _saveRoundData.SaveLetter(_currentLetter);
    }

    private void UpdateInterface(char currentLetter)
    {
        _currentLetter = currentLetter;
        _letterView.SetLetter(currentLetter);
    }
}