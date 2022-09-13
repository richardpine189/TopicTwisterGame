using System;

public interface ILetterView
{
    Action OnAskForLetter { get; set; }

    Action UpdateLetter { get; set; }

    Action OnKeepRoundLetter { get; set; }

    public void SetLetter(char letter);

    public void RequestLetter();
}