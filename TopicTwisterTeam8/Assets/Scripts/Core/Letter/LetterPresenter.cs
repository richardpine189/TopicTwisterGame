using System;
using Zenject;

public class LetterPresenter
{
    private ILetterView _letterView;
    private IGetLetterUseCase _getLetter;
    private ISaveLetterUseCase _saveLetter;

    private char _currentLetter;
    private IGetMatchLetterUseCase _matchLetterUseCase;

    public LetterPresenter(ILetterView letterView, IGetLetterUseCase getLetter, ISaveLetterUseCase saveLetter, IGetMatchLetterUseCase matchLetterUseCase)
    {
        _letterView = letterView;
        _getLetter = getLetter;
        _matchLetterUseCase = matchLetterUseCase;
        _saveLetter = saveLetter;
        UnityEngine.Debug.Log("Im LetterPresenter");
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
        char? tempLetter = _matchLetterUseCase.Execute();
        if (tempLetter == null)
        {
            tempLetter = _getLetter.Execute();
        }
        UpdateInterface((char)tempLetter);
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