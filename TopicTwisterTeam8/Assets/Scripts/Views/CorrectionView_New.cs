using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CorrectionView_New : MonoBehaviour, ICorrectionView_New
{
    //public event Action<string[], string[], char> OnNextTurnClick;

    [SerializeField]
    private TMP_Text[] _categories;

    [SerializeField]
    private TMP_InputField[] _answersUI;

    [SerializeField]
    private Image[] _resultsUI;

    [SerializeField]
    private TMP_Text _roundLetterUI;

    [SerializeField]
    private Button _nextTurnButton;

    //[SerializeField]
    //private CategoriesDB _categoriesDB;

    [SerializeField]
    private LetterSO _letterSO;

    [SerializeField]
    private Sprite _tickSprite;

    [SerializeField]
    private Sprite _crossSprite;

    [SerializeField]
    private CategoriesSO _categoriesSO;

    [SerializeField]
    private GameObject _endRoundPanel;

    private CorrectionPresenter_New _presenter;
    private string[] _answers;
    private string[] _categoryNames;
    private char _roundLetter;

    public event Action<string[], string[], char> OnStart;

    private void Start()
    {
        Initialize();
    }

    void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        Answers answersObject = AssetDatabase.LoadAssetAtPath<Answers>("Assets/Scripts/pruebaSO.asset");
        _answers = answersObject.AnswersString;
        _categoryNames = _categoriesSO.CategoriesName;
        _roundLetter = _letterSO.Letter;

        _roundLetterUI.text = _roundLetter.ToString();

        new CorrectionPresenter_New(this);
        OnStart?.Invoke(_categoryNames, _answers, _roundLetter);
    }

    public void ShowCorrections(bool[] results)
    {
        ShowAnswers(_answers);

        for(int i = 0; i < 5; i++)
        {
            if (results[i])
            {
                _resultsUI[i].sprite = _tickSprite;
            }
            else
            {
                _resultsUI[i].sprite = _crossSprite;
            }
        }
    }

    private void ShowAnswers(string[] answers)
    {
        for (int i = 0; i < _categoryNames.Length; i++)
            _categories[i].text = _categoryNames[i];

        for (int i = 0; i < _answersUI.Length; i++)
            _answersUI[i].text = answers[i];
    }

    public void SaveMatch()
    {
        _presenter.EndTurn(_categoryNames, _answers, _roundLetter);
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
}

