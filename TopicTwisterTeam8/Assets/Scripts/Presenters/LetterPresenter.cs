using System;
using Zenject;

public class LetterPresenter : IInitializable, IDisposable
{
    private ILetterView _letterView;
    private IGetLetterUseCase _getLetter;
    private ISaveLetterUseCase _saveLetter;

    private char _currentLetter;

    public LetterPresenter(ILetterView letterView, IGetLetterUseCase getLetter, ISaveLetterUseCase saveLetter)
    {
        _letterView = letterView;
        _getLetter = getLetter;
        _saveLetter = saveLetter;
        _letterView.OnAskForLetter += AskForLetter;
        _letterView.OnKeepRoundLetter += KeepLetter;
    }

    ~LetterPresenter()
    {
        _letterView.OnAskForLetter -= AskForLetter;
        _letterView.OnKeepRoundLetter -= KeepLetter;
    }

    public void Dispose() { }

    public void Initialize() { }

    private void AskForLetter()
    {
        char tempLetter = _getLetter.Execute();
        UpdateInterface(tempLetter);
    }

    private void KeepLetter()
    {
        _saveLetter.Execute(_currentLetter);
    }

    private void UpdateInterface(char currentLetter)
    {
        _currentLetter = currentLetter;
        _letterView.SetLetter(currentLetter);
    }
}


