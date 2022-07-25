public class LetterPresenter
{
    private ILetterView _letterView;
    private ILetterAction _letterAction;

    private char _currentLetter;

    public LetterPresenter(ILetterView letterView, ILetterAction letterAction)
    {
        _letterView = letterView;
        _letterAction = letterAction;
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
        char tempLetter = _letterAction.CheckForCurrentLetter();
        UpdateInterface(tempLetter);
    }

    private void KeepLetter()
    {
        _letterAction.KeepNewLetterForRound(_currentLetter);
    }

    private void UpdateInterface(char currentLetter)
    {
        _currentLetter = currentLetter;
        _letterView.SetLetterInUI(currentLetter);
    }
}


