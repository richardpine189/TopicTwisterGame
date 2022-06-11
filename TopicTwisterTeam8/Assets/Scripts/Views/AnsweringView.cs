using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Presenters;
using Assets.Scripts.Repositories;
using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Team8.TopicTwister.Assets.Scripts.Views
{
    public class AnsweringView : MonoBehaviour, IAnsweringView
    {
        private AnswersPresenter _presenter;

        public event Action<string[]> OnStopClick;

        [SerializeField]
        private TMP_Text _roundLetter;

        [SerializeField]
        private TMP_Text[] _categories;

        [SerializeField]
        private TMP_InputField[] _answers;

        [SerializeField]
        private GameObject _nextPanel;

        [SerializeField]
        private LetterSO _letterSO;

        [SerializeField]
        private CategoriesSO _categoriesSO;
        private void Start()
        {
            _presenter = new AnswersPresenter(this, ServiceLocator.Instance.GetService<IAnswerSender>());
            _roundLetter.text = _letterSO.Letter.ToString();

            ShowCategories(); // REVISAR
        }

        public void SendAnswers()
        {
            string[] answers = new string[5];

            for(int i = 0; i < 5; i++)
            {
                answers[i] = _answers[i].text;
            }

            OnStopClick.Invoke(answers);
            _nextPanel.SetActive(true);
            this.gameObject.SetActive(false);
        }

        private void ShowCategories()
        {
            for (int i = 0; i < _categories.Length; i++)
                _categories[i].text = _categoriesSO.CategoriesName[i];
        }
    }
}
