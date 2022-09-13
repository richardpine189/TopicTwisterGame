using System;
using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class LetterView : MonoBehaviour, ILetterView
{
    public Action OnAskForLetter { get; set; }

    public Action UpdateLetter { get; set; }

    public Action OnKeepRoundLetter { get; set; }

    public event Action OnActiveLetterPanel;
    
    [SerializeField]
    private TextMeshProUGUI _letterText;

    [SerializeField]
    private TMP_Text _countdownText;

    [SerializeField]
    private GameObject _getLetterButton;

    [SerializeField]
    private GameObject _reSpinButton;

    [SerializeField]
    private GameObject _nextPanel;

    private Color _spinButtonColor;

    void OnEnable()
    {
        OnActiveLetterPanel?.Invoke();
    }

    public void SetLetter(char letter)
    {
        _letterText.text = letter.ToString();
        //UpdateLetter?.Invoke();
    }

    public void RequestLetter()
    {
        OnAskForLetter?.Invoke();
        StartAnimation();
    }

    public void ReSpin()
    {
        ResetButtonsStatus();

        StopCoroutine(CountdownAnimation());
        Debug.Log("i stoped coroutine");
        RequestLetter();
    }
    public void StartAnimation()
    {
        //Desactivar button component
        Sequence buttonSpinAnimation = DOTween.Sequence();
        buttonSpinAnimation.Append(_getLetterButton.transform.DOScaleX(-1, 0.3f));
        buttonSpinAnimation.Append(_getLetterButton.transform.DOScaleX(1, 0.3f));
        buttonSpinAnimation.SetLoops(3).OnComplete(() =>
            {
                _spinButtonColor = _getLetterButton.GetComponent<Image>().color;
                _getLetterButton.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() =>
                {
                    _getLetterButton.SetActive(false);
                    //_reSpinButton.SetActive(true);
                    _letterText.gameObject.SetActive(true);
                    StartCoroutine(CountdownAnimation());
                });
            }
        );
        
    }
    private IEnumerator CountdownAnimation()
    {
        _countdownText.gameObject.SetActive(true);

        for (int i = 4; i > 0; i--)
        {
            _countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Inside coroutine");
        OnKeepRoundLetter?.Invoke();
        UpdateLetter?.Invoke();

        ResetButtonsStatus();

        _nextPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ResetButtonsStatus()
    {
        _getLetterButton.SetActive(true);
        _countdownText.gameObject.SetActive(false);
        _getLetterButton.GetComponent<Image>().color = _spinButtonColor;
    }
}


