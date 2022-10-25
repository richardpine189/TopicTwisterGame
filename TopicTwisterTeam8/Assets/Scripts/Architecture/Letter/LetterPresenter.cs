﻿using Architecture.Letter.UseCase;
using Architecture.Match.UseCases.GetRoundData;
using Architecture.Match.UseCases.SaveRoundData;

namespace Architecture.Letter
{
    public class LetterPresenter
    {
        private View.ILetterView _letterView;
        private IGetLetterUseCase _getLetter;
        private IGetRoundDataUseCase _getRoundDataUseCase;
        private ISaveRoundDataUseCase _saveRoundDataUseCase;

        private char _currentLetter;
        public LetterPresenter(View.ILetterView letterView, IGetLetterUseCase getLetter, ISaveRoundDataUseCase saveRoundDataUseCase, IGetRoundDataUseCase getRoundDataUseCase)
        {
            _letterView = letterView;
            _getLetter = getLetter;
            _getRoundDataUseCase = getRoundDataUseCase;
            _saveRoundDataUseCase = saveRoundDataUseCase;
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
            char tempLetter = _getRoundDataUseCase.GetCurrentLetter();
            if (tempLetter == '!')
            {
                tempLetter = _getLetter.Invoke();
            }
            UpdateInterface(tempLetter);
        }

        private void KeepLetter()
        {
            _saveRoundDataUseCase.SaveLetter(_currentLetter);
        }

        private void UpdateInterface(char currentLetter)
        {
            _currentLetter = currentLetter;
            _letterView.SetLetter(currentLetter);
        }
    }
}