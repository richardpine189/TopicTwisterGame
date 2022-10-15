using System;

namespace Architecture.Letter.View
{
    public interface ILetterView
    {
        Action OnAskForLetter { get; set; }

        Action UpdateLetter { get; set; }

        Action OnKeepRoundLetter { get; set; }

        event Action OnActiveLetterPanel;

        public void SetLetter(char letter);

        public void RequestLetter();
    }
}