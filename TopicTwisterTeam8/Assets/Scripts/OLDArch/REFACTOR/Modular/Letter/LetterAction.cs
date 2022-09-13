
/*
using System;

public class LetterAction : ILetterAction
{
    private IMatchAction _matchAction;

    public LetterAction(IMatchAction matchAction)
    {
        _matchAction = matchAction;
    }

    public char CheckForCurrentLetter()
    {
        return _matchAction.CurrentRound.letter != null ? _matchAction.CurrentRound.letter : GetNewLetter();
    }

    public void KeepNewLetterForRound(char newLetter)
    {
        _matchAction.CurrentRound.letter = newLetter;
    }

    private char GetNewLetter()
    {
        Random random = new Random();
        char randomLetter = (char)random.Next('A', 'E');
        return randomLetter;
    }
}
*/
public interface ILetterAction
{
    public void KeepNewLetterForRound(char newLetter);
    char CheckForCurrentLetter();
}
/*

public interface IMatchAction
{
    object CurrentRound { get; set; }
}
*/