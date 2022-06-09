using Assets.Scripts.Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        CorrectionPresenter _presenter;


        private void Start()
        {
            _presenter = new CorrectionPresenter(this);
        }

        public void ShowCorrections()
        {
            _presenter.GetCategoriesFromRepository(_categoriesDB);
        }
    }
}
