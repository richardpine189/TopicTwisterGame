using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterView : MonoBehaviour, ILetterView
{
    public Action OnAskForLetter { get; set; }

    public Action<char> UpdateLetter { get; set; }

    public Action OnKeepRoundLetter { get; set; }
    
    [SerializeField]
    private TextMeshProUGUI _letterText;

    [SerializeField]
    private TMP_Text _countdownText;

    [SerializeField]
    private GameObject _getLetterButton;

    [SerializeField]
    private GameObject _nextPanelButton;

    public void SetLetter(char letter)
    {
        _letterText.text = letter.ToString();
        _letterText.gameObject.SetActive(true);
        UpdateLetter?.Invoke(letter);
    }

    public void RequestLetter()
    {
        OnAskForLetter?.Invoke();
        StartCoroutine(CoutdownAnimation());
    }

    public void KeepLetter()
    {
        OnKeepRoundLetter?.Invoke();
    }

    private IEnumerator CoutdownAnimation()
    {
        _countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            _countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        _nextPanelButton.SetActive(true);
        _getLetterButton.SetActive(false);
    }
}

public interface ILetterView
{
    Action OnAskForLetter { get; set; }

    Action<char> UpdateLetter { get; set; }

    Action OnKeepRoundLetter { get; set; }

    public void SetLetter(char letter);

    public void RequestLetter();
}
