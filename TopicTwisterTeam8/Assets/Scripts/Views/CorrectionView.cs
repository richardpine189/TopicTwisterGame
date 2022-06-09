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
        private TMP_Text[] categories;

        [SerializeField]
        private TMP_Text[] playerAnswers;

        [SerializeField]
        private Image[] playerResults;

        [SerializeField]
        private TMP_Text roundLetter;

        [SerializeField]
        private Button nextTurnButton;

        [SerializeField]
        private CategoriesDB _categoriesDB;

        [SerializeField]
        private CategoriesSO _currentCategories;

        [SerializeField]
        private Sprite _tickSprite;

        [SerializeField]
        private Sprite _crossSprite;

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

            bool[] corrections = _presenter.GetCorrections(_currentCategories.CategoriesName, answers);

            for(int i = 0; i < 5; i++)
            {
                if (corrections[i])
                {
                    playerResults[i].sprite = _tickSprite;
                }
                else
                {
                    playerResults[i].sprite = _crossSprite;
                }
            }
        }
    }
}
