using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TopicTwister.Assets.Scripts.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Team8.TopicTwister
{
    public class CorrectionView : MonoBehaviour, ICorrectionView
    {
        public event Action OnNextTurnClick;

        [SerializeField]
        private TMP_Text[] _categories;

        [SerializeField]
        private TMP_InputField[] _playerAnswers;

        [SerializeField]
        private Image[] _playerResults;

        [SerializeField]
        private TMP_Text _roundLetter;

        [SerializeField]
        private Button _nextTurnButton;

        [SerializeField]
        private CategoriesDB _categoriesDB;

        [SerializeField]
        private LetterSO _letterSO;

        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField]
        private Sprite _crossSprite;

        [SerializeField]
        private CategoriesSO _categoriesSO;

        CorrectionPresenter _presenter;


        private void Start()
        {
            _presenter = new CorrectionPresenter(this, _categoriesDB);

            ShowCorrections();
        }

        public void ShowCorrections()
        {
            Answers answersObject = AssetDatabase.LoadAssetAtPath<Answers>("Assets/Scripts/pruebaSO.asset");
            string[] answers = answersObject.AnswersString;

            ShowAnswers(answers);

            bool[] corrections = _presenter.GetCorrections(_categoriesSO.CategoriesName, answers, _letterSO.Letter);

            for(int i = 0; i < 5; i++)
            {
                if (corrections[i])
                {
                    _playerResults[i].sprite = _tickSprite;
                }
                else
                {
                    _playerResults[i].sprite = _crossSprite;
                }
            }
        }

        private void ShowAnswers(string[] answers)
        {
            for (int i = 0; i < _categories.Length; i++)
                _categories[i].text = _categoriesSO.CategoriesName[i];

            for (int i = 0; i < _playerAnswers.Length; i++)
                _playerAnswers[i].text = answers[i];
        }
    }
}
