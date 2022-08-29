using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Core.Match.Service;
using Assets.Scripts.Core.Match.UseCases;

public class CorrectionView : MonoBehaviour, ICorrectionView
{
    public event Action EndTurn;

    [SerializeField]
    private TMP_Text[] _categoriesUI;

    [SerializeField]
    private TMP_Text[] _answersUI;

    [SerializeField]
    private Image[] _resultsUI;

    [SerializeField]
    private Sprite _tickSprite;

    [SerializeField]
    private Sprite _crossSprite;

    [SerializeField]
    private GameObject _endRoundPanel;

    [SerializeField]
    private ErrorPanel _errorPanel;

    [SerializeField]
    private GameObject _spiner;

    [SerializeField]
    private RouteConfig _config;

    private CorrectionPresenter _presenter;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _presenter = new CorrectionPresenter(this, new CorrectionGetter(new CategoryService(_config.path)), new UpdateMatchUseCase(new MatchService("http://localhost:8082")));
    }

    public void ShowCorrections(bool[] corrections)
    {
        _spiner.SetActive(false);
        
        for(int i = 0; i < 5; i++)
        {
            _resultsUI[i].gameObject.SetActive(true);
            if (corrections[i] == true)
            {
                _resultsUI[i].sprite = _tickSprite;
            }
            else
            {
                _resultsUI[i].sprite = _crossSprite;
            }
        }
    }

    public void ShowAnswers(string[] answers)
    {
        for (int i = 0; i < _answersUI.Length; i++)
        {
            _answersUI[i].text = answers[i];
        }
    }

    public void ShowCategories(string[] categories)
    {
        for (int i = 0; i < _categoriesUI.Length; i++)
        {
            _categoriesUI[i].text = categories[i];
        }
    }

    public void SaveMatch()
    {
        EndTurn?.Invoke();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void LoadNextTurn()
    {
        _endRoundPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ShowErrorPanel(string message)
    {
        _errorPanel.SetMessage(message);
        _errorPanel.gameObject.SetActive(true);
    }
}
