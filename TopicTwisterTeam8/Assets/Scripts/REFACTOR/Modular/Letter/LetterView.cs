using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterView : MonoBehaviour, ILetterView
{
    public Action OnAskForLetter { get; set; }
    public Action OnKeepRoundLetter { get; set; }
    
    [SerializeField] private TextMeshProUGUI[] _letterText;

    public void SetLetterInUI(char letter)
    {
        foreach (var l in _letterText)
        {
            l.text = letter.ToString();
        }
    }

    public void RequestLetter()
    {
        OnAskForLetter?.Invoke();
    }

    public void KeepLetter()
    {
        OnKeepRoundLetter?.Invoke();
    }
}

public interface ILetterView
{
    Action OnAskForLetter { get; set; }
    Action OnKeepRoundLetter { get; set; }
    public void SetLetterInUI(char letter);
    public void RequestLetter();
}
