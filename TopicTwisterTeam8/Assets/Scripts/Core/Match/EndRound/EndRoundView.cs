using System;
using System.Collections;
using System.Collections.Generic;
using Core.Match.TitleHeaderView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndRoundView : MonoBehaviour, IEndRoundView
{
    
    private const string PANEL_NAME = "FINAL DE RONDA";
    
    [SerializeField]
    private TextMeshProUGUI[] _categories;

    [SerializeField]
    private TextMeshProUGUI[] _challengerAnswers;

    [SerializeField]
    private TextMeshProUGUI[] _opponentAnswers;

    [SerializeField]
    private Image[] _challengerResult;

    [SerializeField]
    private Image[] _opponentResult;

    [SerializeField]
    private Sprite _tickSprite;

    [SerializeField]
    private Sprite _crossSprite;

    [SerializeField]
    private GameObject _endgamePanel;

    [SerializeField]
    private GameObject _categoriesPanel;
    
    [SerializeField]
    private GameObject _nextRoundButton;


    void OnEnable()
    {
        _nextRoundButton.GetComponent<Button>().enabled = true;
        TitleSetName.SendPanelName(PANEL_NAME);
        OnSetRoundResults?.Invoke();
    }

    public event Action OnSetRoundResults;

    public void ShowCategories(string[] categories)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            _categories[i].text = categories[i];
        }
    }

    public void ShowChallengerAnswersAndResult(string[] answers, bool[] results)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            _challengerAnswers[i].text = answers[i];

            if(results[i] == true)
            {
                _challengerResult[i].sprite = _tickSprite;
            }
            else
            {
                _challengerResult[i].sprite = _crossSprite;
            }
        }
    }

    public void ShowOponentAnswersAndResult(string[] answers, bool[] results)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            _opponentAnswers[i].text = answers[i];

            if (results[i] == true)
            {
                _opponentResult[i].sprite = _tickSprite;
            }
            else
            {
                _opponentResult[i].sprite = _crossSprite;
            }
        }
    }

    public void ChangePanel()
    {
        _nextRoundButton.GetComponent<Button>().enabled = false;
        _categoriesPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ShowEndGamePanel(bool challengerWon)
    {
        TMP_Text text = _endgamePanel.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
        text.text = challengerWon ? "Ganaste!" : "Perdiste :(";
        _nextRoundButton.SetActive(false);
        _endgamePanel.SetActive(true);
    }

    public void BackToMain()
    {
        _nextRoundButton.GetComponent<Button>().enabled = false;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
